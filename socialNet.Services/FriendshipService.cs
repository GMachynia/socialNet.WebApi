using AutoMapper;
using socialNet.Data.Models;
using socialNet.Dtos.RequestDtos;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FriendshipService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddUserToFriends(string username, string friendUsername)
        {
            if(username != friendUsername)
            {
                var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
                var friend = await _unitOfWork.Users.GetUserByUsernameAsync(friendUsername);
                var friendship = new Friendship()
                {
                    User = user,
                    UserFriend = friend,
                    Status = FriendRequestStatus.None
                };
                await _unitOfWork.Friendships.AddAsync(friendship);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<bool> IsFriend(string username, string friendUsername)
        {
            if (username != friendUsername)
            {
                var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
                var friend = await _unitOfWork.Users.GetUserByUsernameAsync(friendUsername);
                return await _unitOfWork.Friendships.IsFriend(user, friend);
            }
            return true;
        }

        public async Task UpdateFriendshipStatus(int userId, UpdateFriendshipStatusRequestDto updateFriendshipStatusRequestDto)
        {
            var userFriend = await _unitOfWork.Users.GetUserByIdAsync(userId);
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(updateFriendshipStatusRequestDto.FriendUsername);
            var friendship = await _unitOfWork.Friendships.GetFriendshipByUsers(user, userFriend);

            if (friendship == null)
                throw new ArgumentException("FriendshipNotFound");
           
            friendship.Status = (FriendRequestStatus)updateFriendshipStatusRequestDto.Status;
            await _unitOfWork.CommitAsync();
        }

    }
}
