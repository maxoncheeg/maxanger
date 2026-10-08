using Maxanger.Domain.Entities.Messages.Polls;
using Maxanger.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages.Polls;

public class PollVoteTypeConfiguration : IEntityTypeConfiguration<PollVote>
{
    public void Configure(EntityTypeBuilder<PollVote> builder)
    {
        builder.ToTable("poll_votes").HasKey(x => new {x.PollOptionId, x.UserId});
        
        builder.HasOne<User>(x => x.User).WithMany(x => x.PollVotes).HasForeignKey(x => x.UserId);
        builder.HasOne<PollOption>(x => x.PollOption).WithMany(x => x.PollVotes).HasForeignKey(x => x.PollOptionId);
    }
}