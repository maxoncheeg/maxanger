using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Convertors;
using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Chats;
using Maxanger.Infrastructure.Entities.Messages;
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
        
        builder.Property(x => x.Status).HasConversion(
            v => DatabaseEnumConvertor.ConvertToString(v),
            v => DatabaseEnumConvertor.ConvertStringToEnum<MessageStatus>(v));

        builder.ToTable("chat_messages").HasKey(x => x.Id);
        
        builder.HasIndex(x => new { x.ChatId, x.Id })
            .IsDescending(false, true);

        builder.HasOne<Chat>(x => x.Chat).WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.ChatId);
        builder.HasOne<User>(x => x.From).WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.FromId);
        builder.HasOne<Message>(x => x.ReplyToMessage).WithMany(x => x.Replies)
            .HasForeignKey(x => x.ReplyToMessageId);
        builder.HasQueryFilter(x => !x.SoftDeleted);
    }
}