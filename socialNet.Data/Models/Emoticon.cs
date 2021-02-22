using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Emoticon
    {
        public int EmoticonId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public EmoticonType Type { get; set; }
    }

   public enum EmoticonType
    {
        type1,
        type2,
        type3,
        type4
    }
}
