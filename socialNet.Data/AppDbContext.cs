using Microsoft.EntityFrameworkCore;
using socialNet.Data.ModelBuilders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace socialNet.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.AddUserBuilder();
        }
        

    }
}
