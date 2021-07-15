using Dapper;
using DynamicConfiguration.Application.Interfaces;
using DynamicConfiguration.Core.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicConfiguration.Infrastructure.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IConfiguration _configuration;

        public ConfigurationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> Add(Configuration entity)
        {
            var sql = "INSERT INTO Configurations (Name, Type, Value, IsActive, ApplicationName) Values (@Name, @Type, @Value, @IsActive, @ApplicationName);";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Configurations WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows;
            }
        }

        public async Task<Configuration> Get(int id)
        {
            var sql = "SELECT * FROM Configurations WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Configuration>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Configuration>> GetAll()
        {
            var sql = "SELECT * FROM Configurations;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Configuration>(sql);
                return result;
            }
        }

        public async Task<int> Update(Configuration entity)
        {
            var sql = "UPDATE Configurations SET Name = @Name, Type = @Type, Value = @Value, IsActive = @IsActive, ApplicationName = @ApplicationName WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
    }
}
