using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.TypeConfigurations
{
    public class MessageEntityTypeConfiguration: IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(x => x.MessageId);
            builder
                .HasOne(x => x.Sender)
                .WithMany(x => x.SenderMessages)
                .HasForeignKey(f => f.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(f => f.Recipient)
                .WithMany(x => x.RecipientMessages)
                .HasForeignKey(f => f.RecipientId);
   
        }
    }
}
