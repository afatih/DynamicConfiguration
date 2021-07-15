namespace DynamicConfiguration.ConfigurationReader.Model
{
    public class DynamicConfigurationProviderOptions
    {
        public string ApplicationName { get; set; }
        public string ConnectionString { get; set; }
        public double RefreshTimerIntervalInMs { get; set; }
    }
}
