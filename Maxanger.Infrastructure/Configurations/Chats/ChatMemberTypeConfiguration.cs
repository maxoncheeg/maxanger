using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Entities.Users;
using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Chats;

public class ChatMemberTypeConfiguration : IEntityTypeConfiguration<ChatMember>
{
    public void Configure(EntityTypeBuilder<ChatMember> builder)
    {
        builder.Property(x => x.Role).HasConversion(
            v => DatabaseEnumConvertor.ConvertToString(v),
            v => DatabaseEnumConvertor.ConvertStringToEnum<MemberRole>(v));
        builder.Property(x => x.Status).HasConversion(
            v => DatabaseEnumConvertor.ConvertToString(v),
            v => DatabaseEnumConvertor.ConvertStringToEnum<MemberStatus>(v));
        
        builder.ToTable("chat_members").HasKey(x => new { x.ChatId, x.UserId });
        
        builder.HasOne<User>(x => x.User).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.UserId);
        builder.HasOne<Chat>(x => x.Chat).WithMany(x => x.ChatMembers)
            .HasForeignKey(x => x.ChatId);
    }
}