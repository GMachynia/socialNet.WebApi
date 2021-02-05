using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.ModelBuilders
{
    public static class UserBuilder
    {
        public static ModelBuilder AddUserBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(s => s.Id);

            return modelBuilder;
        }
    }
}
