using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;
using Tax_Radar_Domain.Entities;

namespace TaxRadar_Infrastructure.Persistance.Configuration;

public class ExpenseConfiguration:IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(e => e.Description).HasMaxLength(500).IsRequired();
        builder.Property(e => e.Category).HasConversion<string>();
        builder.Property(e => e.Deductibility).HasConversion<string>();
        builder.Property(e => e.ReceiptImageUrl).HasMaxLength(2000).IsRequired(false);
        builder.Property(e => e.AiSuggestedCategory).HasConversion<string>();
        builder.Property(e => e.AiSuggestedDeductibility).HasConversion<string>();
        builder.ComplexProperty(e => e.Amount, m =>
        {
            m.Property(x => x.Amount).HasPrecision(18, 2);
            m.Property(x => x.Currency).HasConversion<string>();
        });
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}