using Tax_Radar_Domain.Common;
using Tax_Radar_Domain.Enums;
using Tax_Radar_Domain.ValueObjects;

namespace Tax_Radar_Domain.Entities;

public class InvoiceItem : BaseEntity
{
    public Guid InvoiceId { get; private set; }
    public string Description { get; private set; }
    public decimal Quantity { get; private set; }
    public Money UnitPrice { get; private set; }
    public decimal VatRatePercent { get; private set; }

    protected InvoiceItem()
    {
        Description = string.Empty;
        UnitPrice = null!;
    }

    internal InvoiceItem(Guid invoiceId, string description, decimal quantity, decimal unitPrice, Currency currency, decimal vatRatePercent)
    {
        if (invoiceId == Guid.Empty)
            throw new ArgumentException("InvoiceId is required.", nameof(invoiceId));

        ValidateFields(description, quantity, unitPrice, vatRatePercent);

        InvoiceId = invoiceId;
        Description = description;
        Quantity = quantity;
        UnitPrice = new Money(unitPrice, currency);
        VatRatePercent = vatRatePercent;
    }

    public void UpdateDetails(string description, decimal quantity, decimal unitPrice, decimal vatRatePercent)
    {
        ValidateFields(description, quantity, unitPrice, vatRatePercent);

        Description = description;
        Quantity = quantity;
        UnitPrice = new Money(unitPrice, UnitPrice.Currency);
        VatRatePercent = vatRatePercent;
        MarkAsUpdated();
    }

    public Money GetNetAmount() => UnitPrice * Quantity;

    public Money GetVatAmount() => GetNetAmount() * (VatRatePercent / 100m);

    public Money GetGrossAmount() => GetNetAmount() + GetVatAmount();

    private static void ValidateFields(string description, decimal quantity, decimal unitPrice, decimal vatRatePercent)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.", nameof(description));
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPrice < 0)
            throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");
        if (vatRatePercent < 0)
            throw new ArgumentOutOfRangeException(nameof(vatRatePercent), "VAT rate cannot be negative.");
    }
}
