using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Messages.Polls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages.Polls;

public class PollVoteTypeConfiguration : IEntityTypeConfiguration<PollVote>
{
    public void Configure(EntityTypeBuilder<PollVote> builder)
    {
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PollId).HasColumnName("poll_id");
        builder.Property(x => x.UserId).HasColumnName("user_id");
        
        builder.ToTable("poll_votes").HasKey(x => x.Id);

        builder.HasOne<Poll>(x => x.Poll).WithMany(x => x.Votes).HasForeignKey(x => x.PollId);
        builder.HasOne<User>(x => x.User).WithMany(x => x.PollVotes).HasForeignKey(x => x.UserId);
    }
}