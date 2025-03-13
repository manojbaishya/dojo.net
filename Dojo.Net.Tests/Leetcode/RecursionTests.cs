using System;
using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(Recursion))]
public class RecursionTests
{
    private readonly ITestOutputHelper _logger;

    public RecursionTests(ITestOutputHelper logger)
    {
        _logger = logger;
        var converter = new ConsoleConverter(logger);
        Console.SetOut(converter);
    }

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
}
