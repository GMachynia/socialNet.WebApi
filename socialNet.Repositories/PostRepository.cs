using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IPost;

namespace socialNet.Repositories
{
    public class PostRepository:  Repository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
