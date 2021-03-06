﻿using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public virtual User CommentOwner { get; set; }
        public int CommentOwnerId { get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
    }
}
