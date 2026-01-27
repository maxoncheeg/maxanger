using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Messages;

public class EventTypeConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.StatusTypeId).HasColumnName("status_type_id");
        builder.Property(x => x.AffectedUserId).HasColumnName("affected_user_id");
        
        builder.ToTable("events").HasKey(x => x.Id);
        
        builder.HasOne<User>(x => x.AffectedUser).WithMany(x => x.Events).HasForeignKey(x => x.AffectedUserId);

        builder.HasBaseType<MessageContent>();
    }
}