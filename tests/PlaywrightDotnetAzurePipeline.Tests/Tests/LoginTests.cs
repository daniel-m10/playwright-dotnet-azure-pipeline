using Microsoft.Extensions.DependencyInjection;
using PlaywrightDotnetAzurePipeline.Framework.Configuration;
using PlaywrightDotnetAzurePipeline.Framework.Pages;
using PlaywrightDotnetAzurePipeline.Tests.Fixtures;

namespace PlaywrightDotnetAzurePipeline.Tests.Tests;

[TestFixture]
[Category("Login")]
public class LoginTests : BaseTest
{
    private LoginPage _loginPage = null!;
    private TestConfiguration _configuration = null!;

    [SetUp]
    public void LoginTestsSetUp()
    {
        _loginPage = Services.GetRequiredService<LoginPage>();
        _configuration = Services.GetRequiredService<TestConfiguration>();
    }

    [Test]
    public async Task ShouldLoginWithValidCredentials()
    {
        await _loginPage.GoToAsync();
        await _loginPage.LoginAsync(username: "john", password: "demo");

        await Expect(Page).ToHaveURLAsync($"{_configuration.BaseUrl}/overview.htm");
    }
}