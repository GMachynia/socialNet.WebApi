using Microsoft.EntityFrameworkCore;
using socialNet.Data.TypeConfigurations;
using socialNet.Data.Models;
using System;

namespace socialNet.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public AppDbContext(DbContextOptions options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder){ 
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new FriendshipEntityTypeConfiguration().Configure(modelBuilder.Entity<Friendship>());
            new ConnectionEntityTypeConfiguration().Configure(modelBuilder.Entity<Connection>());
            new MessageEntityTypeConfiguration().Configure(modelBuilder.Entity<Message>());
            new PostEntityTypeConfiguration().Configure(modelBuilder.Entity<Post>());
            new CommentEntityTypeConfiguration().Configure(modelBuilder.Entity<Comment>());
            new NotificationEntityTypeConfiguration().Configure(modelBuilder.Entity<Notification>());
        }
        

    }
}
