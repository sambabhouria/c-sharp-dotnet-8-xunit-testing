namespace UnitTestConsoleApp;
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public bool IsOddNumber(int number)
    {
      return number % 2 != 0;
    }

    public void ThrowAnError(string _customMessage)
    {
        throw new InvalidOperationException(_customMessage);
    }

}