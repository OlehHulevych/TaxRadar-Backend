using Microsoft.EntityFrameworkCore;
using Tax_Radar_Domain.Entities;

namespace TaxRadar_Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();
    
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Expense> Expenses => Set<Expense>();

    // InvoiceItem has no DbSet on purpose: it's only reachable via Invoice.Items,
    // matching the internal-only InvoiceItem constructor that makes Invoice the sole entry point.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
