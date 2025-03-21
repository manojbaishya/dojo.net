using System;
using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(EasyProblemsTests))]
public class EasyProblemsTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;
    private readonly EasyProblems sut = new();

    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("MMMCMXCIX", 3999)]
    [InlineData("MMMCXCIX", 3199)]
    [InlineData("XLIX", 49)]
    [InlineData("CMXCIX", 999)]
    public void RomanToInt(string input, int expected)
    {
        int actual = sut.RomanToInt(input);
        Assert.Equivalent(expected, actual);
    }
}
