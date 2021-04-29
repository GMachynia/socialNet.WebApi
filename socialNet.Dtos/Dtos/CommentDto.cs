using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Dtos
{
    public class CommentDto
    {
        public string Content { get; set; }
        public int CommentOwnerId { get; set; }
        public int PostId { get; set; }
        public string Username { get; set; }
    }
}
