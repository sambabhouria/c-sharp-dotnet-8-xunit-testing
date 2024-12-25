namespace UnitTestConsoleApp;

using System.Collections;
using System.Collections.Generic;

public class ComplexInlineDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { 2, 3, 5 },
        new object[] { -2, -3, -5 },
        new object[] { 0, 0, 0 },
        new object[] { 1000, 500, 1500 },
        new object[] { 1, -1, 0 },
        new object[] { 2147483647, 1, -2147483648 },
        new object[] { -2147483648, -1, 2147483647 },
        new object[] { int.MaxValue, 0, int.MaxValue },
        new object[] { int.MinValue, 0, int.MinValue },
        new object[] { 2147483647, -2147483648, -1 },
        new object[] { int.MaxValue, int.MaxValue, -2 },
        new object[] { int.MinValue, int.MinValue, 0 },
        new object[] { 0, 2147483647, 2147483647 },
        new object[] { 0, int.MinValue, int.MinValue },
        new object[] { int.MinValue, int.MaxValue, -1 }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();


    // private readonly List<object[]> _data1 = new List<object[]>
    // {
    //     new object[] {5, 1, 3, 9},
    //     new object[] {7, 1, 5, 3}
    // };

    // public IEnumerator<object[]> GetEnumerator() => _data1.GetEnumerator();
    // IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();



}