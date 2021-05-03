using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos
{
    public record PostDto(string Username, string ProfilePicture,  int PostId, string PostContent, string PostImage, DateTime PostDateTime, IEnumerable<PostCommentDto> Comments);
}
