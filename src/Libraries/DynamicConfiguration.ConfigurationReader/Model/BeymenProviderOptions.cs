namespace DynamicConfiguration.ConfigurationReader.Model
{
    public class BeymenProviderOptions
    {
        public string ApplicationName { get; set; }
        public string ConnectionString { get; set; }
        public double RefreshTimerIntervalInMs { get; set; }
    }
}
