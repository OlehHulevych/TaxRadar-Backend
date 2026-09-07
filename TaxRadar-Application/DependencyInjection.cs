using System.Reflection;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace TaxRadar_Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(_ => { }, typeof(DependencyInjection).Assembly);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}