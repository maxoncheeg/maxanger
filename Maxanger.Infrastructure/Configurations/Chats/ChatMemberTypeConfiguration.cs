using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Chats;

public class ChatMemberTypeConfiguration : IEntityTypeConfiguration<ChatMember>
{
    public void Configure(EntityTypeBuilder<ChatMember> builder)
    {
        builder.Property(x => x.Role)
            .HasConversion(
                v => v.ToString().ToLower(),
                v => Enum.Parse<MemberRole>(v)
                );
        builder.Property(x => x.Status)
            .HasConversion(
                v => v.ToString().ToLower(),
                v => Enum.Parse<MemberStatus>(v)
            );

        builder.ToTable("chat_members").HasKey(x => new { x.ChatId, x.UserId });


        builder.HasOne<User>(x => x.User).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.UserId);
        builder.HasOne<Chat>(x => x.Chat).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.ChatId);
    }
}