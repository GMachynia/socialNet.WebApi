using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
            PostDateTime = DateTime.UtcNow;
        }
        public int PostId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User PostOwner { get; set; }
        public int PostOwnerId { get; set; }
        public string PostImage { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDateTime { get; set; }


    }
}
