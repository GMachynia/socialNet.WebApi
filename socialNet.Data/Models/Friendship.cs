using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Friendship
    {
        public int UserId { get; set; }
        public  virtual User User { get; set; }
        public int UserFriendId { get; set; }
        public  virtual User UserFriend { get; set; }
        public FriendRequestStatus Status { get; set; }
    }

    public enum FriendRequestStatus
    {
        None,
        Approved,
        Rejected,
        Blocked
    };
}
