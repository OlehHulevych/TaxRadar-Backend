using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using TaxRadar_Application.Interfaces;
using TaxRadar_Infrastructure.Persistance;
using TaxRadar_Infrastructure.Repository;

namespace TaxRadar_Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((options) =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IClientRepository, ClientRepository>();
        return services;
    }
}