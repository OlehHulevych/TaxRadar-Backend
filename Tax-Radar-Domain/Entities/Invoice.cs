using Tax_Radar_Domain.Common;
using Tax_Radar_Domain.Enums;
using Tax_Radar_Domain.ValueObjects;

namespace Tax_Radar_Domain.Entities;

public class Invoice : BaseEntity
{
    private readonly List<InvoiceItem> _items = [];

    public Guid UserId { get; private set; }
    public Guid ClientId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public DateOnly IssueDate { get; private set; }
    public DateOnly DueDate { get; private set; }
    public Currency Currency { get; private set; }
    public InvoiceStatus Status { get; private set; }
    public string? Notes { get; private set; }

    public IReadOnlyList<InvoiceItem> Items => _items;

    protected Invoice()
    {
        InvoiceNumber = string.Empty;
    }

    public Invoice(
        Guid userId,
        Guid clientId,
        string invoiceNumber,
        DateOnly issueDate,
        DateOnly dueDate,
        Currency currency,
        string? notes = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.", nameof(userId));
        if (clientId == Guid.Empty)
            throw new ArgumentException("ClientId is required.", nameof(clientId));
        if (string.IsNullOrWhiteSpace(invoiceNumber))
            throw new ArgumentException("Invoice number is required.", nameof(invoiceNumber));
        if (dueDate < issueDate)
            throw new ArgumentException("Due date cannot be before issue date.", nameof(dueDate));

        UserId = userId;
        ClientId = clientId;
        InvoiceNumber = invoiceNumber;
        IssueDate = issueDate;
        DueDate = dueDate;
        Currency = currency;
        Notes = notes;
        Status = InvoiceStatus.Draft;
    }

    public InvoiceItem AddItem(string description, decimal quantity, decimal unitPrice, decimal vatRatePercent)
    {
        EnsureEditable();

        var item = new InvoiceItem(Id, description, quantity, unitPrice, Currency, vatRatePercent);
        _items.Add(item);
        MarkAsUpdated();

        return item;
    }

    public void RemoveItem(Guid itemId)
    {
        EnsureEditable();

        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is null)
            throw new InvalidOperationException($"Invoice item '{itemId}' was not found on this invoice.");

        _items.Remove(item);
        MarkAsUpdated();
    }

    public void UpdateDetails(string invoiceNumber, DateOnly issueDate, DateOnly dueDate, string? notes)
    {
        EnsureEditable();

        if (string.IsNullOrWhiteSpace(invoiceNumber))
            throw new ArgumentException("Invoice number is required.", nameof(invoiceNumber));
        if (dueDate < issueDate)
            throw new ArgumentException("Due date cannot be before issue date.", nameof(dueDate));

        InvoiceNumber = invoiceNumber;
        IssueDate = issueDate;
        DueDate = dueDate;
        Notes = notes;
        MarkAsUpdated();
    }

    public void MarkAsSent()
    {
        if (Status != InvoiceStatus.Draft)
            throw new InvalidOperationException($"Only draft invoices can be sent. Current status: {Status}.");

        Status = InvoiceStatus.Sent;
        MarkAsUpdated();
    }

    public void MarkAsPaid()
    {
        if (Status is not (InvoiceStatus.Sent or InvoiceStatus.Overdue))
            throw new InvalidOperationException($"Only sent or overdue invoices can be marked as paid. Current status: {Status}.");

        Status = InvoiceStatus.Paid;
        MarkAsUpdated();
    }

    public void MarkAsOverdue()
    {
        if (Status != InvoiceStatus.Sent)
            throw new InvalidOperationException($"Only sent invoices can be marked as overdue. Current status: {Status}.");

        Status = InvoiceStatus.Overdue;
        MarkAsUpdated();
    }

    public void Cancel()
    {
        if (Status == InvoiceStatus.Paid)
            throw new InvalidOperationException("Paid invoices cannot be cancelled.");

        Status = InvoiceStatus.Cancelled;
        MarkAsUpdated();
    }

    public Money GetTotalGrossAmount() => new(_items.Sum(i => i.GetGrossAmount().Amount), Currency);

    private void EnsureEditable()
    {
        if (Status != InvoiceStatus.Draft)
            throw new InvalidOperationException("Only draft invoices can be modified.");
    }
}
