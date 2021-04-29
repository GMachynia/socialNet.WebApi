using AutoMapper;
using socialNet.Data.Models;
using socialNet.Dtos;
using socialNet.Dtos.RequestDtos;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Post> AddNewPost(NewPostRequestDto newPost, int userId)
        {
            var postToAdd = _mapper.Map<Post>(newPost);
            postToAdd.PostOwnerId = userId;
            await _unitOfWork.Posts.AddAsync(postToAdd);
            await _unitOfWork.CommitAsync();
            return postToAdd;
        }

        public async Task<IEnumerable<PostDto>> GetPosts(int page, int pageSize, int userId)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            var users = await _unitOfWork.Friendships.GetFriends(user);
                return await _unitOfWork.Posts.GetPosts(users, page, pageSize);
        }

        public async Task<Post> GetPostsById(int postId)
        {
            return await _unitOfWork.Posts.GetPostById(postId);   
        }
    }
}
