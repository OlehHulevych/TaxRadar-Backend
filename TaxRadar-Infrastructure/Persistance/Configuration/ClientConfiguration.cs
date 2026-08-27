
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tax_Radar_Domain.Entities;
using Tax_Radar_Domain.ValueObjects;

namespace TaxRadar_Infrastructure.Persistance.Configuration;

public class ClientConfiguration:IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasIndex(c => c.Email).IsUnique();
        builder.HasOne<User>().WithMany().HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(c => c.Email).HasMaxLength(256).HasConversion<string>(e=>(e==null?null:e.Value) ?? "", eValue=>new EmailAddress(eValue));
        builder.Property(c => c.Ico).HasMaxLength(8).HasConversion<string>(i=>(i==null? null:i.Value) ?? "", iString => new Ico(iString));
        builder.Property(c => c.Dic).HasMaxLength(12).HasConversion<string>(d=>(d==null?null:d.Value) ?? "", dString=>new Dic(dString));
        builder.ComplexProperty(c => c.Address, a =>
        {
            a.IsRequired(false);
            a.Property(x => x.Street).HasMaxLength(200);
            a.Property(x => x.City).HasMaxLength(100);
            a.Property(x => x.PostalCode).HasMaxLength(20);
            a.Property(x => x.Country).HasMaxLength(100);
        });


    }
}