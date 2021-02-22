using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Connection
    {
        public string ConnectionId { get; set; }
        public int UserId { get; set; }
        public  virtual User User { get; set; }
    }
}
