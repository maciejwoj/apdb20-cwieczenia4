namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnFalseWhenNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.False(result);

    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Action
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);

    }

    [Fact]
    public void AddUser_ReturnsFalseWhenEmailIsNotValid()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowalcom",
            new DateTime(2000, 01, 01),
            1
        );

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenAgeIsBelow21()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            new System.DateTime(2005, 01, 01),
            1
        );

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsMailValid_ReturnsFalse_WhenFirstNameIsNull()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.IsMailValid(null, "Kowalski", "kowalski@example.com");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsMailValid_ReturnsFalse_WhenLastNameIsNull()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.IsMailValid("Jan", null, "jan@example.com");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsMailValid_ReturnsFalse_WhenEmailDoesNotContainAtSymbol()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.IsMailValid("Jan", "Kowalski", "invalidemailcom");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsMailValid_ReturnsFalse_WhenEmailDoesNotContainDot()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.IsMailValid("Jan", "Kowalski", "invalidemailcom");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsMailValid_ReturnsTrue_WhenEmailIsValid()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.IsMailValid("Jan", "Kowalski", "jan.kowalski@example.com");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAgeValid_ReturnsFalse_WhenAgeIsUnder21()
    {
        // Arrange
        var userService = new UserService();
        var dateOfBirth = new System.DateTime(2005, 6, 1);

        // Act
        var result = userService.IsAgeValid(dateOfBirth);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAgeValid_ReturnsTrue_WhenAgeIs21()
    {
        // Arrange
        var userService = new UserService();
        var dateOfBirth = System.DateTime.Now.AddYears(-21);

        // Act
        var result = userService.IsAgeValid(dateOfBirth);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAgeValid_ReturnsTrue_WhenAgeIsOver21()
    {
        // Arrange
        var userService = new UserService();
        var dateOfBirth = System.DateTime.Now.AddYears(-22);

        // Act
        var result = userService.IsAgeValid(dateOfBirth);

        // Assert
        Assert.True(result);
    }
    


    
    
}


