using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tax_Radar_Domain.Entities;
using Tax_Radar_Domain.ValueObjects;

namespace TaxRadar_Infrastructure.Persistance.Configuration;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasIndex(e => e.Email).IsUnique();
        builder.Property(e => e.Email)
            .HasConversion(e => e.Value, eString => new EmailAddress(eString)).HasMaxLength(256);
        builder.Property(e => e.FullName).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Ico).HasMaxLength(8).HasConversion<string>(i=>i==null?"":i.Value, value=>new Ico(value));
        builder.Property(e => e.Dic).HasMaxLength(12).HasConversion<string>(d=>d==null?"":d.Value, value=>new Dic(value));
    }
}