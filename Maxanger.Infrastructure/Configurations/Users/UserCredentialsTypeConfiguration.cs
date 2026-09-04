using Maxanger.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Users;

public class UserCredentialsTypeConfiguration : IEntityTypeConfiguration<UserCredentials>
{
    public void Configure(EntityTypeBuilder<UserCredentials> builder)
    {
        builder.ToTable("user_credentials").HasKey(x => x.UserId);

        builder.HasOne<User>(x => x.User).WithOne(x => x.UserCredentials)
            .HasForeignKey<UserCredentials>(x => x.UserId);
    }
}