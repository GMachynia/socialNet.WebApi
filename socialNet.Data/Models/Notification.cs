using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public NotificationType NotificationType { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public enum NotificationType
    {
        NewMessage,
        NewPost,
        NewFriend     
    };
}
