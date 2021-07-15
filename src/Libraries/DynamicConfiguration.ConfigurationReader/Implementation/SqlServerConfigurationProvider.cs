using Dapper;
using DynamicConfiguration.ConfigurationReader.Interface;
using DynamicConfiguration.ConfigurationReader.Model;
using DynamicConfiguration.Core.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace DynamicConfiguration.ConfigurationReader.Implementation
{
    public class SqlServerConfigurationProvider : IBeymenConfigurationProvider
    {
        private const string CacheKey = "BeymenConfigurations";
        private readonly IMemoryCache _memoryCache;
        private readonly Timer _timer;
        private readonly BeymenProviderOptions _options;

        public SqlServerConfigurationProvider(IMemoryCache memoryCache, BeymenProviderOptions options)
        {
            _options = options;
            _memoryCache = memoryCache;
            _timer = new Timer(options.RefreshTimerIntervalInMs);
            Task.Run(async () => await LoadData());
            _timer.Elapsed += _timer_Elapsed; ;
            _timer.Start();
        }

        public async Task<T> GetValue<T>(string key)
        {
            var config = await GetSettingsAsync(key);
            if (config == null)
            {
                //In this part, an error can be thrown or a log record can be made to the db.
                //throw new Exception($"No records found for {key}");
                return default(T);
            }

            var requestedType = (typeof(T)).Name.ToLower();
            var realType = config.Type.ToLower();
            if (!requestedType.Equals(realType))
            {
                //In this part, an error can be thrown or a log record can be made to the db.
                //throw new Exception($"An incorrect return type was selected for {key}");
                return default(T);
            }

            var convertedValue = (T)Convert.ChangeType(config.Value, typeof(T));

            return convertedValue;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            try
            {
                using var sqlConnection = new SqlConnection(_options.ConnectionString);

                var result = await sqlConnection.QueryAsync<Configuration>("SELECT * FROM Configurations where ApplicationName=@ApplicationName and IsActive=1",
                    new { ApplicationName = new DbString { Value = _options.ApplicationName } });

                _memoryCache.Set(CacheKey, result);
            }
            catch (Exception ex)
            {
                //In this part, an error can be thrown or a log record can be made to the db.
            }
        }

        private async Task<Configuration> GetSettingsAsync(string key)
        {
            var configuration = new Configuration();
            try
            {
                using var sqlConnection = new SqlConnection(_options.ConnectionString);

                configuration = (await sqlConnection.QueryAsync<Configuration>
                    ("SELECT * FROM Configurations where ApplicationName=@ApplicationName and Name=@Name and IsActive=1",
                    new
                    {
                        ApplicationName = new DbString { Value = _options.ApplicationName },
                        Name = new DbString { Value = key }
                    })).FirstOrDefault();

                return configuration;
            }
            catch
            {
                configuration = _memoryCache.Get<List<Configuration>>(CacheKey).FirstOrDefault(c => c.Name == key);
            }

            return configuration;
        }
    }
}