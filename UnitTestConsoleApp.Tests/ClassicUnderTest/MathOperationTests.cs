using System.Runtime.CompilerServices;
using UnitTestConsoleApp;
    public class MathOperationTest
    {
        [Fact]
        public void Task_Add_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 6;
            // Act
            var sum = MathOperation.Add(num1, num2);
            // Assert
            Assert.Equal(expectedValue, sum, 1);
        }
        [Fact]
        public void Task_Subtract_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = -0.2;
            // Act
            var sub = MathOperation.Subtract(num1, num2);
            // Assert
            Assert.Equal(expectedValue, sub, 1);
        }

        
        [Fact]
        public void Task_Multiply_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 8.99;
            // Act
            var multiply = MathOperation.Multiply(num1, num2);
            // Assert
            Assert.Equal(expectedValue, multiply, 2);
        }


        [Fact]
        public void Task_Divide_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 0.94; // Rounded value
            // Act
            var div = MathOperation.Divide(num1, num2);
            // Assert
            Assert.Equal(expectedValue, div, 2);
        }

        // Test for IsOddNumber

        [Fact]
        public void IsOddNumber_ValueOf3_ShouldReturnTrue()
        {
          Assert.True(MathOperation.IsOddNumber(3));
        }

        [Fact]
        public void IsOddNumber_ValueOf6_ShouldReturnFalse()
        {
          Assert.False(MathOperation.IsOddNumber(6));
        }

        // Test for IsEvenNumber

        [Fact]
        public void IsEvenNumber_ValueOf3_ShouldReturnFalse()
        {
          Assert.False(MathOperation.IsEvenNumber(3));
        }
      
        [Fact]
        public void IsEvenNumber_ValueOf6_ShouldReturnTrue()
        {
          Assert.True(MathOperation.IsEvenNumber(6));
        }


        // Theory testing
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsTheory_OddNumber_ValueOf3_ShouldReturnTrue(int number)
        {
          Assert.True(MathOperation.IsOddNumber(number));
        }

 [      Theory]
        [InlineData(2)]
        [InlineData(8)]
        [InlineData(10)]
        public void IsTheory_OddNumber_ValueOf6_ShouldReturnFalse(int number)
        {
          Assert.False(MathOperation.IsOddNumber(number));
        }

        [Theory]
        [InlineData(5, 1, 3, 9)]
        [InlineData(7, 1, 5, 3)]
        public void AllNumbers_AreOdd_WithInlineData(int a, int b, int c, int d)
        {
            Assert.True(MathOperation.IsOddNumber(a));
            Assert.True(MathOperation.IsOddNumber(b));
            Assert.True(MathOperation.IsOddNumber(c));
            Assert.True(MathOperation.IsOddNumber(d));
        }

        [Fact]
        public void RatingScore_ValueOf7_EqualsGreat()
        {
          Assert.Equal("Great", MathOperation.RatingScore(7));
        }

        [Fact]
        public void RatingScore_ValueOf7_DoesNotEqualsBad()
        {
          Assert.NotEqual("Bad", MathOperation.RatingScore(7));
        }

        // Theory testing


        [Theory]
        [InlineData(2,"Bad" )]
        [InlineData(5,"Ok" )]
        [InlineData(9,"Great" )]
        public void RatingScore_Values_EqualCorrectRating(int number, string rating)
        {
          Assert.Equal(rating, MathOperation.RatingScore(number));
        }

    }
