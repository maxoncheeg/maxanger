using Maxanger.Domain.Entities.Access;
using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maxanger.Infrastructure.Configurations.Access;

public class AccessTicketTypeConfiguration : IEntityTypeConfiguration<AccessTicket>
{
    public void Configure(EntityTypeBuilder<AccessTicket> builder)
    {
        builder.Property(x => x.Type).HasConversion(
            v => DatabaseEnumConvertor.ConvertToString(v),
            v => DatabaseEnumConvertor.ConvertStringToEnum<AccessTicketType>(v));
        
        builder.ToTable("access_tickets").HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Code).IsUnique();
    }
}