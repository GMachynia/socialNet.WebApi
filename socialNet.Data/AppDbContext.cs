using Microsoft.EntityFrameworkCore;
using socialNet.Data.TypeConfigurations;
using socialNet.Data.Models;


namespace socialNet.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }

        public AppDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){ 
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new FriendshipEntityTypeConfiguration().Configure(modelBuilder.Entity<Friendship>());
            new ConnectionEntityTypeConfiguration().Configure(modelBuilder.Entity<Connection>());
            new MessageEntityTypeConfiguration().Configure(modelBuilder.Entity<Message>());
        }
        

    }
}
