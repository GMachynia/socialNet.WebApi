using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace socialNet.Data.Models
{
    public class User
    {
        public User()
        {
            UserFriendships = new List<Friendship>();
            Friendships = new List<Friendship>();
            Posts = new List<Post>();
            Comments = new List<Comment>();
            SenderMessages = new List<Message>();
            RecipientMessages = new List<Message>();
            Notifications = new List<Notification>();
            Connections = new List<Connection>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public virtual ICollection<Connection> Connections { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Friendship> UserFriendships { get; set; }
        public virtual ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<Message> SenderMessages{ get; set; }
        public virtual ICollection<Message> RecipientMessages { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}
