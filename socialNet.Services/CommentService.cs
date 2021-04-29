using AutoMapper;
using socialNet.Data.Models;
using socialNet.Dtos;
using socialNet.Dtos.RequestDtos;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services
{
    public class CommentService: ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentDto> AddComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            var user = await _unitOfWork.Users.GetUserByIdAsync(commentDto.CommentOwnerId);
            commentDto.Username = user.Username;
            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.CommitAsync();
            return commentDto;
        }
    }
}
