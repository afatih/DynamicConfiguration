using DynamicConfiguration.Application.Interfaces;

namespace DynamicConfiguration.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConfigurationRepository configurationRepository)
        {
            Configurations = configurationRepository;
        }
        public IConfigurationRepository Configurations { get; }
    }
}
