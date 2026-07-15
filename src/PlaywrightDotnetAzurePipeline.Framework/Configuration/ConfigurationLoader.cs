using Microsoft.Extensions.Configuration;

namespace PlaywrightDotnetAzurePipeline.Framework.Configuration;

public static class ConfigurationLoader
{
    public static TestConfiguration Load()
    {
        var environment = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "dev";
        
        var configurationRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

        var testConfiguration = new TestConfiguration();
        configurationRoot.GetSection("TestConfiguration").Bind(testConfiguration);
        
        return testConfiguration;
    }
}