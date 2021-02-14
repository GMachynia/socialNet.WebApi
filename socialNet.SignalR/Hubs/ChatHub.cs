
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace socialNet.SignalR.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        [HubMethodName("SendToAll")]
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
        [HubMethodName("SendToCaller")]
        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }
        [HubMethodName("SendToUser")]
        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("SendToGroup")]
        public Task SendMessageToGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("Join")]
        public Task JoinToGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Chat: UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("Chat: UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
