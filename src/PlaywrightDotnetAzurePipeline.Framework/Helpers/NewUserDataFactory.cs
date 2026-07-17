namespace PlaywrightDotnetAzurePipeline.Framework.Helpers;

public abstract class NewUserDataFactory
{
    public static NewUserData CreateValid(string? username = null)
    {
        var uniqueUsername = username ?? $"testuser_{Guid.NewGuid():N}"[..17];
        var uniqueSsn = GenerateFakeSsn();
        const string password = "SecurePassword123!";

        return new NewUserData
        (
            FirstName: "John",
            LastName: "Doe",
            Street: "123 Main Street",
            City: "New York",
            State: "NY",
            ZipCode: "10001",
            PhoneNumber: "5551234567",
            Ssn: uniqueSsn,
            UserName: uniqueUsername,
            Password: password,
            ConfirmPassword: password
        );
    }

    private static string GenerateFakeSsn()
    {
        var random = Random.Shared;
        return $"9{random.Next(10, 99)}-{random.Next(10, 99)}-{random.Next(1000, 9999)}";
    }
}