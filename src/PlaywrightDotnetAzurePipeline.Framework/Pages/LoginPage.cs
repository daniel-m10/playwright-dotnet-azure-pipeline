using Microsoft.Playwright;
using PlaywrightDotnetAzurePipeline.Framework.Configuration;

namespace PlaywrightDotnetAzurePipeline.Framework.Pages;

public class LoginPage(IPage page, TestConfiguration configuration)
{
    private const string RelativePath = "/index.htm";
    private readonly ILocator _usernameInput = page.Locator("input[name='username']");
    private readonly ILocator _passwordInput = page.Locator("input[name='password']");
    private readonly ILocator _loginButton = page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Log In" });

    public async Task GoToAsync()
    {
        await page.GotoAsync($"{configuration.BaseUrl}{RelativePath}");
    }

    public async Task LoginAsync(string username, string password)
    {
        await _usernameInput.FillAsync(username);
        await _passwordInput.FillAsync(password);
        await _loginButton.ClickAsync();
    }
}