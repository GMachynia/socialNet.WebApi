using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;

namespace socialNet.Data.TypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.City).IsRequired().HasMaxLength(20);
            builder.Property(x => x.DateOfBirth).IsRequired().HasColumnType("date");
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
        }
    }
}
