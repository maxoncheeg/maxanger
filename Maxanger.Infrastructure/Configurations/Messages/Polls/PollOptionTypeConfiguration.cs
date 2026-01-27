using Maxanger.Infrastructure.Entities.Messages;
using Maxanger.Infrastructure.Entities.Messages.Polls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages.Polls;

public class PollOptionTypeConfiguration : IEntityTypeConfiguration<PollOption>
{
    public void Configure(EntityTypeBuilder<PollOption> builder)
    {
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PollId).HasColumnName("poll_id");
        builder.Property(x => x.Text).HasColumnName("text");
        
        builder.ToTable("poll_options").HasKey(x => x.Id);

        builder.HasOne<Poll>(x => x.Poll).WithMany(x => x.Options).HasForeignKey(x => x.PollId);
    }
}