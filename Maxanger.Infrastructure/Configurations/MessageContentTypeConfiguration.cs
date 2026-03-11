using Maxanger.Infrastructure.Entities.Chats;
using Maxanger.Infrastructure.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations;

public class MessageContentTypeConfiguration : IEntityTypeConfiguration<MessageContent>
{
    public void Configure(EntityTypeBuilder<MessageContent> builder)
    {
        builder.ToTable("message_contents").HasKey(x => x.Id);

        builder.HasOne<ChatMessage>(x => x.ChatMessage).WithOne(x => x.Content)
            .HasForeignKey<MessageContent>(x => x.ChatMessageId);
    }
}