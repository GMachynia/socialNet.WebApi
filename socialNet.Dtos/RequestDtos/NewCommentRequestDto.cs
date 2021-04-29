using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos.RequestDtos
{
    public class NewCommentRequestDto
    {
        public string content { get; set; }
        public int postId { get; set; }
    }
}
