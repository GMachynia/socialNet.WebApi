using socialNet.Data.Models;
using socialNet.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Repsitories.Interfaces.IPost
{
    public interface IPostQueryRepository
    {
        Task<IEnumerable<PostDto>> GetPosts(IEnumerable<User> friendshipUsers, int page, int pageSize);
        Task<Post> GetPostById(int postId);
        Task<IEnumerable<int>> GetPostUserIds(int userId);
    }
}
