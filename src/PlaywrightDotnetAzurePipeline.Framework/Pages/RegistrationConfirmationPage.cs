using Microsoft.Playwright;

namespace PlaywrightDotnetAzurePipeline.Framework.Pages;

public class RegistrationConfirmationPage(IPage page)
{
    public ILocator ConfirmationMessage =>
        page.GetByText("Your account was created successfully. You are now logged in.");
}