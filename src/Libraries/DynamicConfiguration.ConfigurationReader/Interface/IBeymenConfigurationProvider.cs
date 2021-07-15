using System.Threading.Tasks;

namespace DynamicConfiguration.ConfigurationReader.Interface
{
    public interface IBeymenConfigurationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<T> GetValue<T>(string key);
    }
}
