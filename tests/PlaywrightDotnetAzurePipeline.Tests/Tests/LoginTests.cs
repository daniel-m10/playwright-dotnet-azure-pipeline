using Microsoft.Extensions.DependencyInjection;
using PlaywrightDotnetAzurePipeline.Framework.Pages;
using PlaywrightDotnetAzurePipeline.Tests.Fixtures;

namespace PlaywrightDotnetAzurePipeline.Tests.Tests;

[TestFixture]
[Category("Login")]
public class LoginTests : BaseTest
{
    private LoginPage _loginPage = null!;
    private AccountsOverviewPage _accountsOverviewPage = null!;

    [SetUp]
    public void LoginTestsSetUp()
    {
        _loginPage = Services.GetRequiredService<LoginPage>();
        _accountsOverviewPage = Services.GetRequiredService<AccountsOverviewPage>();
    }

    [Test]
    public async Task ShouldLoginWithValidCredentials()
    {
        await _loginPage.GoToAsync();
        await _loginPage.LoginAsync(username: "john", password: "demo");

        await Expect(_accountsOverviewPage.AccountOverviewHeading).ToBeVisibleAsync();
    }
}