using Xunit;
namespace UnitTestConsoleApp.Tests;
/*
In this example:
We have a CalculatorTests class containing tests for the Add method of the Calculator class.
We use [Theory] attribute to denote parameterized tests.
We use [InlineData] attribute to provide inline data for simple test cases.
We define a custom data generator class ComplexInlineDataGenerator implementing IEnumerable<object[]> to generate complex inline data.
The ComplexInlineDataGenerator class provides a collection of test cases with complex inline data.
Each test case consists of three integers: a, b, and the expected result expected.
We use Assert.Equal to verify that the actual result matches the expected result.

*/
public class CalculatorTests {

  private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }


    [Fact]
    public void Add_WhenCalled_ReturnsSumOfArguments()
    {
        // Arrange
        // var calculator = new Calculator();

        // Act
        var result = _calculator.Add(1, 2);

        // Assert
        Assert.Equal(3, result);
    }

    

    [Theory]
    [InlineData(2, 3, 5)] // Simple inline data
    [InlineData(-2, -3, -5)] // Simple inline data with negative numbers
    [InlineData(0, 0, 0)] // Simple inline data with zeros
    [InlineData(1000, 500, 1500)] // Simple inline data with large numbers
    [InlineData(1, -1, 0)] // Simple inline data with mixed positive and negative numbers
    [InlineData(2147483647, 1, -2147483648)] // Simple inline data with maximum integer value
    [InlineData(-2147483648, -1, 2147483647)] // Simple inline data with minimum integer value
    [InlineData(int.MaxValue, 0, int.MaxValue)] // Simple inline data with maximum integer value and zero
    [InlineData(int.MinValue, 0, int.MinValue)] // Simple inline data with minimum integer value and zero
    [InlineData(2147483647, -2147483648, -1)] // Simple inline data with maximum and minimum integer values
    [InlineData(int.MaxValue, int.MaxValue, -2)] // Simple inline data with two maximum integer values
    [InlineData(int.MinValue, int.MinValue, 0)] // Simple inline data with two minimum integer values
    [InlineData(0, 2147483647, 2147483647)] // Simple inline data with zero and maximum integer value
    [InlineData(0, int.MinValue, int.MinValue)] // Simple inline data with zero and minimum integer value
    [InlineData(int.MinValue, int.MaxValue, -1)] // Simple inline data with maximum and minimum integer values
    public void Add_WithInlineData_ReturnsExpectedResult(int a, int b, int expected)
    {
        // Arrange

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(ComplexInlineDataGenerator))]
    public void Add_WithComplexInlineData_ReturnsExpectedResult(int a, int b, int expected)
    {
        // Arrange

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 1, 3, 9)]
    [InlineData(7, 1, 5, 3)]
    public void AllNumbers_AreOdd_WithInlineData(int a, int b, int c, int d)
    {
        Assert.True(_calculator.IsOddNumber(a));
        Assert.True(_calculator.IsOddNumber(b));
        Assert.True(_calculator.IsOddNumber(c));
        Assert.True(_calculator.IsOddNumber(d));
    }


    // [Theory]
    // [ClassData(typeof(ComplexInlineDataGenerator))]
    // public void AllNumbers_AreOdd_WithClassData(int a, int b, int c, int d)
    // {
    //     Assert.True(_calculator.IsOddNumber(a));
    //     Assert.True(_calculator.IsOddNumber(b));
    //     Assert.True(_calculator.IsOddNumber(c));
    //     Assert.True(_calculator.IsOddNumber(d));
    // }
}