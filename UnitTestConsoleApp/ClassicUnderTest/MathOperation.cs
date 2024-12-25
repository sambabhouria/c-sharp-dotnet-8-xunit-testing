

namespace  UnitTestConsoleApp
{
    public static class MathOperation
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }
        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }
        public static double Divide(double number1, double number2)
        {
            return number1 / number2;
        }
        public static bool IsOddNumber(int number)
        {
            return number % 2 == 1;
        }
        public static bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }
        public static string RatingScore (int number) => number switch
        {
            < 3 => "Bad",
            >=3  and < 7  => "Ok",
            >= 7  and <= 10 => "Great",
            _ => "unknown"
          
        };
    }
}