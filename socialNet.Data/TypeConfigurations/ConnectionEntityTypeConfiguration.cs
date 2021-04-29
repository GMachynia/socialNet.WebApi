using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.TypeConfigurations
{
    public class ConnectionEntityTypeConfiguration : IEntityTypeConfiguration<Connection>
    {
        public void Configure(EntityTypeBuilder<Connection> builder)
        {
            builder
                .HasKey(x => x.ConnectionId);
            builder
            .HasOne(x => x.User)
            .WithMany(x => x.Connections)
            .HasForeignKey(x => x.UserId);
        }
    }
}
