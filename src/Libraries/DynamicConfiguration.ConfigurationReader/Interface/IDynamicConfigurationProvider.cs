using System.Threading.Tasks;

namespace DynamicConfiguration.ConfigurationReader.Interface
{
    public interface IDynamicConfigurationProvider
    {
        Task<T> GetValue<T>(string key);
    }
}