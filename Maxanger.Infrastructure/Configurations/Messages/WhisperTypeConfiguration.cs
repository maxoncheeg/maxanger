using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages;

public class WhisperTypeConfiguration : IEntityTypeConfiguration<Whisper>
{
    public void Configure(EntityTypeBuilder<Whisper> builder)
    {
        builder.ToTable("whispers");
        
        builder.HasOne<User>(x => x.To).WithMany(x => x.Whispers).HasForeignKey(x => x.ToId);

        builder.HasBaseType<MessageContent>();
    }
}