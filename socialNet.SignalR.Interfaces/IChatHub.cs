using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.SignalR.Interfaces
{
    public interface IChatHub
    {
        Task SendMessageToAll(string message);
        Task SendMessageToCaller(string message);
        Task SendMessageToUser(string connectionId, string message);

    }
}
