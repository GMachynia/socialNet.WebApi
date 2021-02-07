using Microsoft.EntityFrameworkCore;
using socialNet.Data.TypeConfigurations;
using socialNet.Data.Models;


namespace socialNet.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){ 
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

        }
        

    }
}
