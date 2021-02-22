using socialNet.Data.Models;
using socialNet.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IFriendship
{
    public interface IFriendshipQueryRepository
    {
        Task<bool> IsFriend(User user, User friend);
        Task<IEnumerable<UserInvitationDto>> GetUserInvitations(User user);
        Task<Friendship> GetFriendshipByUsers(User user, User userFriend);
    }
}
