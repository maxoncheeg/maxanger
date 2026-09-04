using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Entities.Users;
using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages;

public class MessageTypeConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(x => x.Type).HasConversion(
            v => DatabaseEnumConvertor.ConvertToString(v),
            v => DatabaseEnumConvertor.ConvertStringToEnum<MessageType>(v));

        builder.Property(x => x.Metadata).HasColumnType("jsonb");

        builder.ToTable("chat_messages").HasKey(x => x.Id);
        
        builder.HasIndex(x => new { x.ChatId, x.FromId, x.Id })
            .IsDescending(false, false, true);
        
        builder.HasOne<Chat>(x => x.Chat).WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.ChatId);
        builder.HasOne<User>(x => x.From).WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.FromId);
        builder.HasOne<Message>(x => x.ReplyToMessage).WithMany(x => x.Replies)
            .HasForeignKey(x => x.ReplyToMessageId);
        builder.HasQueryFilter(x => !x.SoftDeleted);
    }
}