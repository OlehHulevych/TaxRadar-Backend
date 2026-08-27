using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tax_Radar_Domain.Common;

namespace TaxRadar_Infrastructure.Persistance.Configuration;

public static class BaseEntityConfigurationExtensions
{
    public static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedNever();
        builder.Property(b => b.CreatedAt).IsRequired();
        builder.Property(b => b.UpdatedAt);
        
    }
}