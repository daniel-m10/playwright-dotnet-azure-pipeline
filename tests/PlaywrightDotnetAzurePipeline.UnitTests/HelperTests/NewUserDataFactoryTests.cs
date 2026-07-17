using PlaywrightDotnetAzurePipeline.Framework.Helpers;

namespace PlaywrightDotnetAzurePipeline.UnitTests.HelperTests;

[TestFixture]
[Category("Helper: NewUserDataFactoryTests")]
public class NewUserDataFactoryTests
{
    [Test]
    public void CreateValid_CalledTwice_ReturnsDifferentUsernames()
    {
        var uniqueUsernameOne = NewUserDataFactory.CreateValid();
        var uniqueUsernameTwo = NewUserDataFactory.CreateValid();
        
        Assert.That(uniqueUsernameOne.UserName, Is.Not.EqualTo(uniqueUsernameTwo.UserName));
    }
    
    [Test]
    public void CreateValid_Always_ReturnsMatchingPasswordAndConfirmPassword()
    {
        var uniqueUsername =  NewUserDataFactory.CreateValid();
        
        Assert.That(uniqueUsername.Password, Is.EqualTo(uniqueUsername.ConfirmPassword));
    }

    [Test]
    public void CreateValid_Always_ReturnsSsnStartingWithNine()
    {
        var uniqueUsername =  NewUserDataFactory.CreateValid();

        Assert.That(uniqueUsername.Ssn, Does.StartWith("9"));
    }

    [Test]
    public void CreateValid_CalledTwice_ReturnsDifferentSsns()
    {
        var firstUsername = NewUserDataFactory.CreateValid();
        var secondUsername = NewUserDataFactory.CreateValid();
        
        Assert.That(firstUsername.Ssn, Is.Not.EqualTo(secondUsername.Ssn));
    }
}