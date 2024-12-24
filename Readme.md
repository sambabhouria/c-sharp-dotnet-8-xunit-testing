# Step 1: Create a Solution and Console Application

1.  - Open a Terminal or Command Prompt: You can use the terminal in VSCode or any command prompt.

2.  - Create a New Solution:

    dotnet new sln -n UnitTestSolution

    This command creates a new solution file named UnitTestSolution.sln.

3.  - Create a New Console Application:

    dotnet new console -n UnitTestConsoleApp

    This command creates a new directory called UnitTestConsoleApp with a basic .NET console application.

4.  - Navigate to the Console Application Directory:

    cd UnitTestConsoleApp

5.  - Create the UserAccount Class: In the UnitTestConsoleApp project directory, create a new file named UserAccount.cs and add the following code:

    public class UserAccount
    {
    private string \_email;

    public void SetEmail(string email)
    {
    if (string.IsNullOrWhiteSpace(email))
    {
    throw new ArgumentException("Email cannot be null or empty");
    }

        _email = email;

    }

    public string GetEmail()
    {
    return \_email;
    }
    }

6.  - Add the Console Application to the Solution:

      dotnet sln add UnitTestConsoleApp/UnitTestConsoleApp.csproj

      This command adds the console application project to the solution.

# Step 2: Create and Configure the Test Project

1.  - Create a New xUnit Test Project:

      dotnet new xunit -n UnitTestConsoleApp.Tests

      This command creates a new directory called UnitTestConsoleApp.Tests with a basic xUnit test project.

2.  - Navigate to the Test Project Directory:

      cd UnitTestConsoleApp.Tests

3.  - Add xUnit Package: Add the necessary NuGet packages for xUnit:

      dotnet add package xunit

4.  - Reference the Console Application: Add a project reference from the test project to the console application:

      dotnet add reference ../UnitTestConsoleApp/UnitTestConsoleApp.csproj

5.  - Add the Test Project to the Solution: Navigate back to the solution root and add the test project:

      dotnet sln add UnitTestConsoleApp.Tests/UnitTestConsoleApp.Tests.csproj

# Step 3: Write Unit Tests Using xUnit

1.  - Open the Test Project in VSCode: Ensure you have the UnitTestConsoleApp.Tests project open in VSCode.:

2.  - Create Your Test File: For example, create a UserAccountTests.cs file in the UnitTestConsoleApp.Tests directory:

3.  - Write Your Tests: Here’s a sample test file using xUnit:

using Xunit;
using System;
using UnitTestConsoleApp;

    namespace UnitTestConsoleApp.Tests
    {
    public class UserAccountTests
    {
    private UserAccount \_userAccount;

        // This method is run before each test
        public UserAccountTests()
        {
          _userAccount = new UserAccount();
        }

        [Fact]
        public void SetEmail_ValidEmail_EmailIsSet()
        {
          // Arrange
          string email = "test@example.com";

          // Act
          _userAccount.SetEmail(email);

          // Assert
          Assert.Equal(email, _userAccount.GetEmail());
        }

        [Fact]
        public void SetEmail_EmptyEmail_ThrowsArgumentException()
        {
          // Arrange
          string emptyEmail = "";

          // Act and Assert
          var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(emptyEmail));
          Assert.Equal("Email cannot be null or empty", exception.Message);
        }

        [Fact]
        public void GetEmail_NoEmailSet_ReturnsNull()
        {
          // Act
          string email = _userAccount.GetEmail();

          // Assert
          Assert.Null(email);
        }

        [Theory]
        [InlineData("user@example.com")]
        [InlineData("admin@domain.com")]
        [InlineData("support@company.org")]
        public void SetEmails_ValidEmail_EmailIsSet(string email)
        {
          // Act
          _userAccount.SetEmail(email);

          // Assert
          Assert.Equal(email, _userAccount.GetEmail());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")] // Testing a single space as input
        public void SetEmail_InvalidEmail_ThrowsArgumentException(string invalidEmail)
        {
          // Act and Assert
          var exception = Assert.Throws<ArgumentException>(() => _userAccount.SetEmail(invalidEmail));
          Assert.Equal("Email cannot be null or empty", exception.Message);
        }

    }
    }

# Step 4: Run Your Tests

1.  - Run Tests Using the Command Line: From the root directory of your solution, execute:

      dotnet test

      This command runs all the tests in your solution and displays the results in the terminal.

2.  - Run Tests in VSCode: You can also run tests directly within VSCode by using the Test Explorer extension or by running the tests from the terminal.:
