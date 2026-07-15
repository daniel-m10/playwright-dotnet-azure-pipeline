using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Interfaces;
using PlaywrightDotnetAzurePipeline.Framework.Configuration;
using PlaywrightDotnetAzurePipeline.Framework.Pages;

namespace PlaywrightDotnetAzurePipeline.Tests.Fixtures;

public abstract class BaseTest : PageTest
{
    private IServiceScope _scope = null!;
    private IAPIRequestContext _request = null!;
    protected IServiceProvider Services => _scope.ServiceProvider;

    [SetUp]
    public async Task SetUpDependencyInjection()
    {
        var configuration = AssemblySetup.ServiceProvider.GetRequiredService<TestConfiguration>();

        _request = await Playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = configuration.BaseUrl
        });

        var services = new ServiceCollection();

        services.AddSingleton(configuration);
        services.AddSingleton(Page);
        services.AddSingleton(_request);

        services.AddScoped<LoginPage>();

        var scopedProvider = services.BuildServiceProvider();
        _scope = scopedProvider.CreateScope();

        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task TearDownDependencyInjection()
    {
        var failed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;

        if (failed)
        {
            var testPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "playwright-traces",
                $"{TestContext.CurrentContext.Test.Name}.zip");

            await Context.Tracing.StopAsync(new TracingStopOptions { Path = testPath });
        }
        else
        {
            await Context.Tracing.StopAsync(new TracingStopOptions());
        }

        await _request.DisposeAsync();
        _scope.Dispose();
    }
}