using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Chats;

public class ChatTypeConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.Property(x => x.Type).HasConversion(
            v => DatabaseEnumConvertor.ConvertToString(v),
            v => DatabaseEnumConvertor.ConvertStringToEnum<ChatType>(v));
        
        builder.ToTable("chats").HasKey(x => x.Id);
        
        builder.HasQueryFilter(x => !x.SoftDeleted);
    }
}