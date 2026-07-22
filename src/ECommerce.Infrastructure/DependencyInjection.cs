using ECommerce.Application.Interfaces;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Persistence.Postgresql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<NpgsqlConnection>(_ => 
            new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"))
        );
        
        DatabaseInitializer.Initialize(configuration);

        services.AddScoped<IChemicalElementQueryRepository, ChemicalElementQueryRepository>();
        
        return services;
    }
}