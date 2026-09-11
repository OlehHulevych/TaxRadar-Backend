using Tax_Radar_Domain.Entities;

namespace TaxRadar_Application.Interfaces;

public interface IInvoiceRepository:IRepository<Invoice>
{
    public Task<List<Invoice>> GetByUserId(Guid id, CancellationToken cancellationToken);
    public Task AddItemToInvoice(Guid id,InvoiceItem item, CancellationToken cancellationToken);
    public Task RemoveItemFromInvoice(Guid id, InvoiceItem item, CancellationToken cancellationToken);
}