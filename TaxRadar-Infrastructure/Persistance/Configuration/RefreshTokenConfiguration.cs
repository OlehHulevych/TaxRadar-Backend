using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tax_Radar_Domain.Entities;

namespace TaxRadar_Infrastructure.Persistance.Configuration;

public class RefreshTokenConfiguration:IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ConfigureBaseEntity();
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);
        builder.Property(e => e.TokenHash).HasMaxLength(200);
    }
}