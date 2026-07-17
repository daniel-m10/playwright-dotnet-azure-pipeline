using Microsoft.Extensions.DependencyInjection;
using PlaywrightDotnetAzurePipeline.Framework.Helpers;
using PlaywrightDotnetAzurePipeline.Framework.Pages;
using PlaywrightDotnetAzurePipeline.Tests.Fixtures;

namespace PlaywrightDotnetAzurePipeline.Tests.Tests;

[TestFixture]
[Category("Registration")]
public class RegistrationTests : BaseTest
{
    private RegistrationPage _registrationPage = null!;
    private RegistrationConfirmationPage _confirmationPage = null!;

    [SetUp]
    public void RegistrationSetup()
    {
        _registrationPage = Services.GetRequiredService<RegistrationPage>();
        _confirmationPage = Services.GetRequiredService<RegistrationConfirmationPage>();
    }

    [Test]
    public async Task ShouldRegisterNewUserSuccessfully()
    {
        await _registrationPage.GoToAsync();

        var newUser = NewUserDataFactory.CreateValid();
        TestContext.Out.WriteLine(newUser);
        await _registrationPage.RegisterAsync(newUser);

        await Expect(_confirmationPage.ConfirmationMessage).ToBeVisibleAsync();
    }
}