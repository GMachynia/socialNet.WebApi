using Microsoft.EntityFrameworkCore;
using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Dtos;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IFriendship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repositories
{
    public class FriendshipRepository: Repository<Friendship>, IFriendshipRepository
    {
        public FriendshipRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<bool> IsFriend(User user, User friend)
        {
            return await _appDbContext.Friendships.AnyAsync(x => (x.User == user && x.UserFriend == friend && x.Status == FriendRequestStatus.Approved || x.Status == FriendRequestStatus.Approved)
            || (x.User == friend && x.UserFriend == user && x.Status == FriendRequestStatus.Approved || x.Status == FriendRequestStatus.Approved));
        }


        public async Task<IEnumerable<UserInvitationDto>> GetUserInvitations(User user)
        {
            return await _appDbContext.Friendships.Where( x=> x.UserFriend == user && x.Status == FriendRequestStatus.None)
                .Include(x => x.User).Select(x => 
                 new UserInvitationDto(x.User.Username, x.User.FirstName, x.User.LastName)).ToListAsync();
        }

        public async Task<Friendship> GetFriendshipByUsers(User user, User userFriend)
        {
            return await _appDbContext.Friendships.Where(x => x.User == user && x.UserFriend == userFriend).FirstOrDefaultAsync();
          
        }
    }
}
