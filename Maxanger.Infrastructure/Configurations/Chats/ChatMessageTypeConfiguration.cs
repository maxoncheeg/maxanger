using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Chats;
using Maxanger.Infrastructure.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Chats;

public class ChatMessageTypeConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("chat_messages").HasKey(x => x.Id);

        builder.HasOne<Chat>(x => x.Chat).WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.ChatId);
        builder.HasOne<User>(x => x.From).WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.FromId);
        builder.HasQueryFilter(x => !x.SoftDeleted);
    }
}