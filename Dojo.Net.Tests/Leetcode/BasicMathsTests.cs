using System.Collections.Generic;
using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(BasicMaths))]
public class BasicMathsTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(12, 2)]
    public void EvenlyDivides(int number, int expected)
    {
        var sut = new BasicMaths();
        int actual = sut.EvenlyDivides(number);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(9854, 4589)]
    [InlineData(1534236469, 0)]
    [InlineData(-9854, -4589)]
    public void ReverseInteger(int number, int expected)
    {
        var sut = new BasicMaths();
        int actual = sut.ReverseInteger(number);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    public void IsPalindrome(int number, bool expected)
    {
        var sut = new BasicMaths();
        bool actual = sut.IsPalindrome(number);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData(371, true)]
    [InlineData(1634, false)]
    [InlineData(35, false)]
    public void IsArmstrongNumber(int number, bool expected)
    {
        var sut = new BasicMaths();
        bool actual = sut.IsArmstrongNumber(number);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(36, new int[] {36, 18, 12, 9, 6, 4, 3, 2, 1})]
    public void GetAllDivisors(int number, int[] expected)
    {
        var sut = new BasicMaths();
        int[] actual = [.. sut.GetAllDivisorsDesc(number)];

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(36, false)]
    [InlineData(13, true)]
    [InlineData(11, true)]
    [InlineData(1, false)]
    public void IsPrime(int number, bool expected)
    {
        var sut = new BasicMaths();
        bool actual = sut.IsPrime(number);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData(12, 6, 6)]
    [InlineData(27, 18, 9)]
    [InlineData(11, 13, 1)]
    public void HighestCommonFactor(int M, int N, int expected)
    {
        var sut = new BasicMaths();
        int actual = sut.HighestCommonFactor(M, N);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(12, 6, 6)]
    [InlineData(27, 18, 9)]
    [InlineData(11, 13, 1)]
    public void HighestCommonFactorEuclidean(int M, int N, int expected)
    {
        var sut = new BasicMaths();
        int actual = sut.HighestCommonFactorEuclidean(M, N);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }

        [Theory]
    [InlineData(12, 6, 12)]
    [InlineData(27, 18, 54)]
    [InlineData(11, 13, 143)]
    public void LeastCommonMultiple(int M, int N, int expected)
    {
        var sut = new BasicMaths();
        int actual = sut.LeastCommonMultiple(M, N);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }
}
