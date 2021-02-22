using socialNet.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services.Interfaces
{
    public interface IFriendshipService
    {
        Task AddUserToFriends(string username, string friendUsername);
        Task<bool> IsFriend(string username, string friendUsername);
        Task UpdateFriendshipStatus(int userId, UpdateFriendshipStatusRequestDto updateFriendshipStatusRequestDto);

    }
}
