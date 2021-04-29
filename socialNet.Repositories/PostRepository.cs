using Microsoft.EntityFrameworkCore;
using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Dtos;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IPost;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<PostDto>> GetPosts(IEnumerable<User> friendshipUsers, int page, int pageSize)
        {
            return await _appDbContext.Posts
                .Include(x => x.PostOwner)
                .Include(x => x.Comments)
                .Where(x => friendshipUsers.Contains(x.PostOwner))
                .OrderByDescending(x => x.PostDateTime.Day)
                .ThenByDescending(x => x.PostDateTime.TimeOfDay)
                .Select(x => new PostDto(
                    x.PostOwner.Username,
                    x.PostOwner.ProfilePicture,
                    x.PostId,
                    x.PostContent,
                    x.PostImage,
                    x.PostDateTime.ToUniversalTime(),
                    x.Comments
                    ))
                    .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                      .ToListAsync();
        }


        public async Task<Post> GetPostById(int postId)
        {
            return await _appDbContext.Posts.SingleOrDefaultAsync(x => x.PostId == postId);
        }

        public async Task<IEnumerable<int>> GetPostUserIds(int userId)
        {
           return await _appDbContext.Posts.Where(x => x.PostOwnerId == userId).Select(x => x.PostId).ToListAsync();
        }

    }

}
