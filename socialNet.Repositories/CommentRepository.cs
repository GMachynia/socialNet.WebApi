using socialNet.Data;
using socialNet.Data.Models;
using socialNet.Repositories.Repository;
using socialNet.Repsitories.Interfaces.IComment;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Repositories
{
    public class CommentRepository: Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
