using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.TypeConfigurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasKey(x => x.PostId);
        }
    }
}
