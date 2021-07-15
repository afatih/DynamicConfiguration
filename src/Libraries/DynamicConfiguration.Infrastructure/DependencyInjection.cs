using DynamicConfiguration.Application.Interfaces;
using DynamicConfiguration.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicConfiguration.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
