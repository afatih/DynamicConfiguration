namespace DynamicConfiguration.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IConfigurationRepository Configurations { get; }
    }
}
