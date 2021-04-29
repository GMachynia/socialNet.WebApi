using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.TypeConfigurations
{
    public class NotificationEntityTypeConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
                .HasKey(x => x.NotificationId);
            builder
                .HasMany(f => f.Users)
                .WithMany(x => x.Notifications);
            builder
               .Property(x => x.NotificationType)
               .HasConversion<byte>();
        }
    }
}
