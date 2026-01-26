using Maxanger.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Email).HasColumnName("email").IsRequired();
        builder.Property(x => x.Password).HasColumnName("password").IsRequired();
        builder.Property(x => x.RegistrationDate).HasColumnName("registration_date");
        builder.Property(x => x.LastLogin).HasColumnName("last_login").IsRequired();
        builder.Property(x => x.Birthday).HasColumnName("birthday").IsRequired();

        builder.ToTable("users").HasKey(x => x.Id);
    }
}