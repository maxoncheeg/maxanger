using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages;

public class EventTypeConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(x => x.NewStatus)
            .HasConversion(
                v => v.ToString().ToLower(),
                v => Enum.Parse<MemberStatus>(v)
            );
        builder.Property(x => x.PreviousStatus)
            .HasConversion(
                v => v.ToString().ToLower(),
                v => Enum.Parse<MemberStatus>(v)
            );
        
        builder.ToTable("events");
        
        builder.HasOne<User>(x => x.AffectedUser).WithMany(x => x.Events).HasForeignKey(x => x.AffectedUserId);

        builder.HasBaseType<MessageContent>();
    }
}