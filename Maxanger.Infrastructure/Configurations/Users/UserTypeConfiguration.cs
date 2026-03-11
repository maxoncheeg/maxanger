using Maxanger.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Users;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Email).HasColumnName("email").IsRequired();
        builder.Property(x => x.Username).HasColumnName("username").IsRequired();

        builder.ToTable("users").HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Username).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}