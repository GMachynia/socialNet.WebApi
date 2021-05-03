using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IConnection
{
    public interface IConnectionQueryRepository
    {
        Task<IEnumerable<string>> GetFriendsConnectionId(IEnumerable<User> users);
        Task<IEnumerable<string>> GetConnectionIdsByUser(User user);
    }
}
