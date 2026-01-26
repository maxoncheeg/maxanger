using Maxanger.Infrastructure.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Chats;

public class MemberStatusTypeConfiguration : IEntityTypeConfiguration<MemberStatus>
{
    public void Configure(EntityTypeBuilder<MemberStatus> builder)
    {
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name");
        
        builder.ToTable("member_statuses");
    }
}