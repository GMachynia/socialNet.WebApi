using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace socialNet.Repositories
{
    public class ConnectionRepository: Repository<Connection>, IConnectionRepository
    {
        public ConnectionRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<string>> GetOnlineUsers(IEnumerable<User> users)
        {
            return await _appDbContext.Connections.Where(x => users.Contains(x.User)).Select(x=>x.ConnectionId).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetFriendsConnectionId(IEnumerable<User> users)
        {
            return await _appDbContext.Connections.Where(x => users.Contains(x.User)).Select(x => x.ConnectionId).ToListAsync();
        }

        public async Task<Connection> GetConnectionIdByUser(User user)
        {
            return await _appDbContext.Connections.SingleOrDefaultAsync(x => x.User == user);
        }

    }
}
