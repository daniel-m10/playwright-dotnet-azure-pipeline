using Microsoft.Extensions.DependencyInjection;
using PlaywrightDotnetAzurePipeline.Framework.Configuration;

namespace PlaywrightDotnetAzurePipeline.Tests;

[SetUpFixture]
public class AssemblySetup
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    [OneTimeSetUp]
    public void BuildServiceProvider()
    {
        var services = new ServiceCollection();

        var testConfiguration = ConfigurationLoader.Load();
        services.AddSingleton(testConfiguration);
        
        ServiceProvider = services.BuildServiceProvider();
    }

    [OneTimeTearDown]
    public void DisposeServiceProvider()
    {
        (ServiceProvider as IDisposable)?.Dispose();
    }
}