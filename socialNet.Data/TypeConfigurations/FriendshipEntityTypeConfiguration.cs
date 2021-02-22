using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.TypeConfigurations
{
    public class FriendshipEntityTypeConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder
                .HasKey(x => new { x.UserId, x.UserFriendId});
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserFriendships)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(f => f.UserFriend)
                .WithMany(x => x.Friendships)
                .HasForeignKey(f => f.UserFriendId);
            builder
                .Property(x => x.Status)
                .HasConversion<byte>();
        }
    }
}
