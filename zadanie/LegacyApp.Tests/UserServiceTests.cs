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
            new System.DateTime(2005, 01, 01), // Date of birth corresponding to age below 21
            1
        );

        // Assert
        Assert.False(result);
    }
}
