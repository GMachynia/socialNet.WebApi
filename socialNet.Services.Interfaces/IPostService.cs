using socialNet.Data.Models;
using socialNet.Dtos;
using socialNet.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> AddNewPost(NewPostRequestDto newPost, int userId);
        Task<IEnumerable<PostDto>> GetPosts(int page, int pageSize, int userId);
    }
}
