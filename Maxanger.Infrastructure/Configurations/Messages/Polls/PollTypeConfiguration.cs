using Maxanger.Infrastructure.Entities.Messages;
using Maxanger.Infrastructure.Entities.Messages.Polls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages.Polls;

public class PollTypeConfiguration : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        builder.ToTable("polls");

        builder.HasBaseType<MessageContent>();
    }
}