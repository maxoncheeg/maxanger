using Maxanger.Infrastructure.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages;

public class MessageTypeConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Text).HasColumnName("text");
        
        builder.ToTable("messages").HasKey(x => x.Id);

        builder.HasBaseType<MessageContent>();
    }
}