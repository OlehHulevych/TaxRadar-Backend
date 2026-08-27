using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tax_Radar_Domain.Entities;

namespace TaxRadar_Infrastructure.Persistance.Configuration;

public class InvoiceItemConfiguration:IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(e => e.Description).HasMaxLength(500).IsRequired();
        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.VatRatePercent).HasPrecision(5, 2);
        builder.ComplexProperty(e => e.UnitPrice, m =>
        {
            m.Property(x => x.Amount).HasPrecision(18, 2);
            m.Property(x => x.Currency).HasConversion<string>();
        });
       
    }
}