using Microsoft.Playwright;

namespace PlaywrightDotnetAzurePipeline.Framework.Pages;

public class AccountsOverviewPage(IPage page)
{
    public ILocator AccountOverviewHeading { get; } = page.GetByRole(AriaRole.Heading,
        new PageGetByRoleOptions
        {
            Name = "Accounts Overview",
        });
}