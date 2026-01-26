using Maxanger.Infrastructure.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Chats;

public class ChatTypeConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.SoftDeleted).HasColumnName("soft_deleted");
        
        builder.ToTable("chats").HasKey(x => x.Id);
        builder.HasQueryFilter(x => !x.SoftDeleted);
    }
}