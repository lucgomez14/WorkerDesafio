using Andreani.Arq.Cqrs.Extension;
using worker_application.Application.Common.Interfaces;
using worker_application.Infrastructure.Persistence;
using worker_application.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace worker_application.Infrastructure.Boopstrap;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS(configuration)
        .Configure<ApplicationDbContext>();

        services.AddScoped<ICommandSqlServer, CommandSqlServer>();
        services.AddScoped<IQuerySqlServer, QuerySqlServer>();
        services.AddScoped<IPedidoEventService, PedidoEventService>();

        return services;
    }
}