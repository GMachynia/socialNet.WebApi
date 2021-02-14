using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.SignalR.Hubs
{
    [Authorize]
    public class NotificationHub: Hub
    {
        [HubMethodName("SendToAll")]
        public Task SendNotificationToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
        [HubMethodName("SendToCaller")]
        public Task SendNotificationToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }
        [HubMethodName("SendToUser")]
        public Task SendNotificationToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Notification: UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Caller.SendAsync("Notification: UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
