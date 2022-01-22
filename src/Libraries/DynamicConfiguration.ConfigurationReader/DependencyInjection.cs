using DynamicConfiguration.ConfigurationReader.Implementation;
using DynamicConfiguration.ConfigurationReader.Interface;
using DynamicConfiguration.ConfigurationReader.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DynamicConfiguration.ConfigurationReader
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfigurationReader(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDynamicConfigurationProvider>(factory =>
            {
                var memoryCache = factory.GetRequiredService<IMemoryCache>();
                var options = new DynamicConfigurationProviderOptions
                {
                    ApplicationName = configuration.GetSection("ConfigurationSettings:ApplicationName").Value,
                    ConnectionString = configuration.GetSection("ConfigurationSettings:ConnectionString").Value,
                    RefreshTimerIntervalInMs = Convert.ToDouble
                        (configuration.GetSection("ConfigurationSettings:RefreshTimerIntervalInMs").Value)
                };
                return new SqlServerConfigurationProvider(memoryCache, options);
            });

            return services;
        }
    }
}
