using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IMessage
{
    public interface IMessageQueryRepository
    {
        Task<IEnumerable<Message>> GetAllMessagesFromToByUsernameAsync(string sender, string recipient);
        Task<IEnumerable<Message>> GetAllMessagesFromToByIdAsync(int senderId, int recipientId);


    }
}
