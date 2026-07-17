namespace PlaywrightDotnetAzurePipeline.Framework.Helpers;

public record NewUserData(
    string FirstName,
    string LastName,
    string Street,
    string City,
    string State,
    string ZipCode,
    string PhoneNumber,
    string Ssn,
    string UserName,
    string Password,
    string ConfirmPassword
);