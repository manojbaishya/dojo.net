using System;
using System.IO;
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
    public void ReverseArray(int[] input, int[] expected)
    {
        Recursion sut = new();
        int[] actual = sut.ReverseArray(input);

        Assert.Equivalent(expected, actual);
    }
}
