using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(Recursion))]
public class RecursionTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData("Ramesh", 6)]
    [InlineData("Suresh", 15)]
    [InlineData("Mahesh", 20)]
    [InlineData("Five Star", 35)]
    public void PrintStringNTimes(string name, int count)
    {
        var sut = new Recursion();
        sut.PrintStringNTimes(name, 0, count);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(15)]
    [InlineData(20)]
    [InlineData(35)]
    public void PrintNTimes(int count)
    {
        var sut = new Recursion();
        sut.PrintNTimes(0, count);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(15)]
    [InlineData(20)]
    [InlineData(35)]
    public void PrintNTimesReverse(int count)
    {
        var sut = new Recursion();
        sut.PrintNTimesReverse(count, count);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(15)]
    [InlineData(20)]
    [InlineData(35)]
    public void PrintNTimesBacktracking(int count)
    {
        var sut = new Recursion();
        sut.PrintNTimesBacktracking(count, count);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(15)]
    [InlineData(20)]
    [InlineData(35)]
    public void PrintNTimesReverseBacktracking(int count)
    {
        var sut = new Recursion();
        sut.PrintNTimesReverseBacktracking(1, count);
    }

    [Theory]
    [InlineData(6, 441)]
    [InlineData(15, 14400)]
    [InlineData(14, 11025)]
    [InlineData(11, 4356)]
    public void SumOfCubicSeries(int N, double expected)
    {
        var sut = new Recursion();
        double actual = sut.SumOfCubicSeries(N);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(6, 441)]
    [InlineData(15, 14400)]
    [InlineData(14, 11025)]
    [InlineData(11, 4356)]
    public void SumofCubicSeriesbyFormula(int N, double expected)
    {
        var sut = new Recursion();
        double actual = sut.SumofCubicSeriesbyFormula(N);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(6, 21)]
    [InlineData(15, 120)]
    [InlineData(14, 105)]
    [InlineData(11, 66)]
    public void SumOfNNumbers(int N, double expected)
    {
        var sut = new Recursion();
        double actual = sut.SumOfNNumbers(N);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(6, 21)]
    [InlineData(15, 120)]
    [InlineData(14, 105)]
    [InlineData(11, 66)]
    public void SumOfNNumbersbyFormula(int N, double expected)
    {
        var sut = new Recursion();
        double actual = sut.SumOfNNumbersbyFormula(N);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(6, 720)]
    [InlineData(7, 5040)]
    [InlineData(9, 362880)]
    [InlineData(11, 39916800)]
    public void Factorial(int N, double expected)
    {
        var sut = new Recursion();
        double actual = sut.Factorial(N);   

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] {5, 10, 15}, new  int[] {15, 10, 5})]
    [InlineData(new int[] {1, 2, 3, 4, 5}, new int[] {5, 4, 3, 2, 1})]
    [InlineData(new int[] {7, 8, 9}, new int[] {9, 8, 7})]
    [InlineData(new int[] {0, -1, -2}, new int[] {-2, -1, 0})]
    [InlineData(new int[] {100}, new int[] {100})]
    public void ReverseArray(int[] input, int[] expected)
    {
        Recursion sut = new();
        int[] actual = sut.ReverseArray(input);

        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(new int[] {5, 10, 15}, new  int[] {15, 10, 5})]
    [InlineData(new int[] {1, 2, 3, 4, 5}, new int[] {5, 4, 3, 2, 1})]
    [InlineData(new int[] {7, 8, 9}, new int[] {9, 8, 7})]
    [InlineData(new int[] {0, -1, -2}, new int[] {-2, -1, 0})]
    [InlineData(new int[] {100}, new int[] {100})]
    public void ReverseArrayWithSingleIndex(int[] input, int[] expected)
    {
        Recursion sut = new();
        int[] actual = sut.ReverseArrayWithSingleIndex(input);

        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("madam", true)]
    [InlineData("racecar", true)]
    [InlineData("hello", false)]
    [InlineData("level", true)]
    [InlineData("world", false)]
    public void IsPalindrome(string input, bool expected)
    {
        Recursion sut = new();
        bool actual = sut.IsPalindrome(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("madam", true)]
    [InlineData("racecar", true)]
    [InlineData("hello", false)]
    [InlineData("level", true)]
    [InlineData("world", false)]
    public void IsPalindromeChecks(string input, bool expected)
    {
        Recursion sut = new();
        bool actual = sut.IsPalindromeChecks(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData("", true)]
    public void IsPalindromeWithSanitization(string input, bool expected)
    {
        Recursion sut = new();
        bool actual = sut.IsPalindromeWithSanitization(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(10, 55)]
    [InlineData(16, 987)]
    [InlineData(19, 4181)]
    public void FibonacciRecursive(int input, int expected)
    {
        Recursion sut = new();
        int actual = sut.FibonacciRecursive(input);

        Assert.Equal(expected, actual);
    }
}
