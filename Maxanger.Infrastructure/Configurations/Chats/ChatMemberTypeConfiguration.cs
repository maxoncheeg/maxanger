using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Chats;

public class ChatMemberTypeConfiguration : IEntityTypeConfiguration<ChatMember>
{
    public void Configure(EntityTypeBuilder<ChatMember> builder)
    {
        builder.Property(x => x.ChatId).HasColumnName("chat_id");
        builder.Property(x => x.UserId).HasColumnName("user_id");
        builder.Property(x => x.MemberRoleId).HasColumnName("role_id");
        builder.Property(x => x.MemberStatusId).HasColumnName("status_id");

        builder.ToTable("chat_members").HasKey(x => new { x.ChatId, x.UserId });

        builder.HasOne<MemberRole>(x => x.MemberRole).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.MemberRoleId);
        builder.HasOne<MemberStatus>(x => x.MemberStatus).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.MemberStatusId);
        builder.HasOne<User>(x => x.User).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.UserId);
        builder.HasOne<Chat>(x => x.Chat).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.ChatId);
    }
}