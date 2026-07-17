using Microsoft.Playwright;
using PlaywrightDotnetAzurePipeline.Framework.Configuration;
using PlaywrightDotnetAzurePipeline.Framework.Helpers;

namespace PlaywrightDotnetAzurePipeline.Framework.Pages;

public class RegistrationPage(IPage page, TestConfiguration configuration)
{
    private const string RelativePath =  "/register.htm";
    private readonly ILocator _firstNameField = page.Locator("input[name='customer.firstName']");
    private readonly ILocator _lastNameField = page.Locator("input[name='customer.lastName']");
    private readonly ILocator _addressField = page.Locator("input[name='customer.address.street']");
    private readonly ILocator _cityField = page.Locator("input[name='customer.address.city']");
    private readonly ILocator _stateField = page.Locator("input[name='customer.address.state']");
    private readonly ILocator _zipCodeField = page.Locator("input[name='customer.address.zipCode']");
    private readonly ILocator _phoneNumberField = page.Locator("input[name='customer.phoneNumber']");
    private readonly ILocator _ssnField = page.Locator("input[name='customer.ssn']");
    private readonly ILocator _usernameField = page.Locator("input[name='customer.username']");
    private readonly ILocator _passwordField = page.Locator("input[name='customer.password']");
    private readonly ILocator _confirmPasswordField = page.Locator("input[name='repeatedPassword']");

    private readonly ILocator _submitButton = page.GetByRole(AriaRole.Button, new PageGetByRoleOptions
    {
        Name = "Register"
    });
    
    public async Task GoToAsync()
    {
        await page.GotoAsync($"{configuration.BaseUrl}{RelativePath}");
    }

    public async Task RegisterAsync(NewUserData userData)
    {
        await _firstNameField.FillAsync(userData.FirstName);
        await _lastNameField.FillAsync(userData.LastName);
        await _addressField.FillAsync(userData.Street);
        await _cityField.FillAsync(userData.City);
        await _stateField.FillAsync(userData.State);
        await _zipCodeField.FillAsync(userData.ZipCode);
        await _phoneNumberField.FillAsync(userData.PhoneNumber);
        await _ssnField.FillAsync(userData.Ssn);
        await _usernameField.FillAsync(userData.UserName);
        await _passwordField.FillAsync(userData.Password);
        await _confirmPasswordField.FillAsync(userData.ConfirmPassword);
        
        await _submitButton.ClickAsync();
    }
}