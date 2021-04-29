using AutoMapper;
using socialNet.Dtos;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Services.Interfaces;
using System.Threading.Tasks;
using socialNet.Data.Models;
using System.Collections.Generic;

namespace socialNet.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConnectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ConnectionDto> AddConnection(ConnectionDto connectionDto)
        {
            var connection = _mapper.Map<Connection>(connectionDto);
            await _unitOfWork.Connections.AddAsync(connection);
            await _unitOfWork.CommitAsync();
            return connectionDto;
        }

        public async Task<ConnectionDto> RemoveConnection(ConnectionDto connectionDto)
        {
            var connection = _mapper.Map<Connection>(connectionDto);
            _unitOfWork.Connections.Delete(connection);
            await _unitOfWork.CommitAsync();
            return connectionDto;
        }

        public async Task<IEnumerable<string>> GetFriendsConnectionId(int userId){
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            var users = await _unitOfWork.Friendships.GetFriends(user);
            return await _unitOfWork.Connections.GetFriendsConnectionId(users);
        }

        public async Task<string> GetPostOwnerConnectionId (int postId)
        {
            var post = await _unitOfWork.Posts.GetPostById(postId);
            var user = post.PostOwner;
            var connection = await _unitOfWork.Connections.GetConnectionIdByUser(user);
            return connection.ConnectionId;

        }

    }
}
