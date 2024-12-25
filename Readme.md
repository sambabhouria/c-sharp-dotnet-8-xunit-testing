# How to Use xUnit for Unit Testing in .NET Project Using C# in VSCode

# Introduction to xUnit

xUnit support two different types of unit test, Fact and Theory.

1.  - xUnit Fact when we have some criteria that always must be met, regardless of data.
      For example, when we test a controller’s action to see if it’s returning the correct view.

2.  - xUnit Theory on the other hand depends on set of parameters and its data, our test will pass for some set of data and not the others.
      We have a theory which postulate that with this set of data, this will happen.

xUnit is an open-source unit testing tool for the .NET Framework. It is highly extensible and provides
various features to simplify the process of writing and executing unit tests.

# Setting up xUnit

Before writing unit tests, make sure you have installed the xUnit framework in your project.
You can do this using NuGet Package Manager or .NET CLI.
![app](/00.png)

# Introduction

In software development, it’s crucial to make sure your code works correctly. One of the best ways to do this is through unit testing.
Unit testing means testing small parts of your software, like a single function or method, to make sure they work as expected.
In this app, we will learn how to use xUnit for unit testing in .NET projects. We will use C# and Visual Studio Code (VSCode) as our tools.

# Why Is Unit Testing Important?

1.  - Finding Bugs Early: Unit tests help you find problems early in the development process, before the software is fully integrated. This makes it easier and faster to fix issues.
2.  - Better Code Quality: Writing unit tests encourages you to write clean and well-organized code. When you know your code will be tested, you’re more likely to write good, understandable code..
3.  - As you improve or change your code, unit tests help ensure that these changes don’t break existing functionality. This makes it safer to update and improve your software..
4.  - Unit tests can also help explain how the code should work. They serve as examples of how to use the code correctly.
5.  - : In a team, unit tests help make sure that everyone’s code works together smoothly. This is especially important in large projects where many people are working on different parts of the software
      .
6.  - Unit tests help save time and money by catching issues early.

## Screenshots

![app](/AAA.png)
![app](/0.png)
![app](/failecase.png)
![app](/0.png)
![app](/1.png)

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

# Learn Microsoft

0. - https://www.tutorialsteacher.com/
1. - Partial classes : https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods
   - https://www.tutorialsteacher.com/csharp/csharp-partial-class
2. - Déléguee : https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/delegates/
3. - https://www.tutorialsteacher.com/csharp/csharp-delegates
4. - https://www.tutorialsteacher.com/csharp/csharp-delegates
5. - https://www.tutorialsteacher.com/codeeditor?cid=cs-au49Bs

   ![app](/delegate.png)
