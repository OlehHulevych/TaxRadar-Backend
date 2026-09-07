using Microsoft.EntityFrameworkCore;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.Exceptions;
using TaxRadar_Application.Interfaces;
using TaxRadar_Infrastructure.Persistance;

namespace TaxRadar_Infrastructure.Repository;

public class ClientRepository:IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c=>c.Id==id,cancellationToken);
        if (client == null) throw new NotFoundException(nameof(Client), id);
        return client;
    }

    public async Task AddAsync(Client entity, CancellationToken cancellationToken)
    {
         await _context.Clients.AddAsync(entity, cancellationToken);
         await SaveChangesAsync(cancellationToken);


    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Client>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var clients = await _context.Clients.Where(c=>c.UserId == userId).ToListAsync();
        return clients;
    }
}