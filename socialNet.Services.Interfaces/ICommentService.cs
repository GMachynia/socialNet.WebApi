using socialNet.Data.Models;
using socialNet.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto> AddComment(CommentDto commentDto);
    }
}
