using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.TypeConfigurations
{
    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
              .HasKey(x =>  x.CommentId);
            builder
                .HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId);
            builder
                .HasOne(x => x.CommentOwner)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.CommentOwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
