using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IMessage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public Task<IEnumerable<Message>> GetAllMessagesFromToByIdAsync(int senderId, int recipientId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetAllMessagesFromToByUsernameAsync(string sender, string recipient)
        {
            throw new NotImplementedException();
        }
    }
}
