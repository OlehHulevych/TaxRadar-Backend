using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tax_Radar_Domain.Entities;

namespace TaxRadar_Infrastructure.Persistance.Configuration;

public class InvoiceConfiguration:IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasOne<User>().WithMany().HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Client>().WithMany().HasForeignKey(i => i.ClientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(i => i.Items).WithOne().HasForeignKey(ii => ii.InvoiceId).OnDelete(DeleteBehavior.Cascade);
        builder.Navigation(i => i.Items).HasField("_items").UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Property(i => i.Currency).HasConversion<string>();
        builder.Property(i => i.Status).HasConversion<string>();
        builder.Property(i => i.InvoiceNumber).HasMaxLength(100);
        builder.HasIndex(i => new { i.UserId, i.InvoiceNumber }).IsUnique();
        builder.Property(i => i.Notes).HasMaxLength(2000).IsRequired(false);
        
    }
}