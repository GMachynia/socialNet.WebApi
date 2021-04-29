
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using socialNet.Dtos;
using socialNet.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace socialNet.SignalR.Hubs
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SocialNetHub: Hub
    {
        private readonly IConnectionService _connectionService;

        public SocialNetHub(IConnectionService connectionService) : base()
        {
            _connectionService = connectionService;
        }


        [HubMethodName("SendToAll")]
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessageToAll", message);
        }
        [HubMethodName("SendToCaller")]
        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessageToCaller", message);
        }
       
        [HubMethodName("SendToUser")]
        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendToGroup")]
        public Task SendMessageToGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("ReceiveMessageToGroup", message);
        }

        [HubMethodName("Join")]
        public Task JoinToGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        [HubMethodName("AddToGroup")]
        public Task AddUserToGroup(string connectionId, string groupName)
        {
            return Groups.AddToGroupAsync(connectionId, groupName);
        }
        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.Identity.Name;
            var connectionId = Context.ConnectionId;
            await _connectionService.AddConnection(new ConnectionDto(Int32.Parse(userId), connectionId));
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User.Identity.Name;
            var connectionId = Context.ConnectionId;
            await this._connectionService.RemoveConnection(new ConnectionDto(Int32.Parse(userId), connectionId));
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
