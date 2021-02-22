using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace socialNet.Data.Models
{
    public class User
    {
        public User()
        {
            Connections = new List<Connection>();
            UserFriendships = new List<Friendship>();
            Friendships = new List<Friendship>();
            //Posts = new List<Post>();
            SenderMessages = new List<Message>();
            RecipientMessages = new List<Message>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] ProfilePicture { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public virtual ICollection<Connection> Connections { get; set; }
        public virtual ICollection<Friendship> UserFriendships { get; set; }
        public virtual ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<Message> SenderMessages{ get; set; }
        public virtual ICollection<Message> RecipientMessages { get; set; }
        //public virtual ICollection<Post> Posts { get; set; }

    }
}
