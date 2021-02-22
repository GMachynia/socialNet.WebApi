using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Post
    {
        public Post()
        {
            Emoticons = new List<Emoticon>();
            Comments = new List<Comment>();
            PostDateTime = new DateTime();
        }
        public int PostId { get; set; }
        public virtual ICollection<Emoticon> Emoticons { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User PostOwner { get; set; }
        public int PostOwnerId { get; set; }
        public byte[] Image { get; set; }
        public DateTime PostDateTime { get; set; }


    }
}
