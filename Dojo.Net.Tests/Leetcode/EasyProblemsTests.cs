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
        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData(new string[] {"flower","flow","flight"}, "fl")]
    [InlineData(new string[] {"dog","racecar","car"}, "")]
    public void LongestCommonPrefix(string[] input, string expected)
    {
        string actual = sut.LongestCommonPrefix(input);
        _logger.WriteLine($"Expected: {expected}, Actual: {actual}");
        Assert.Equal(expected, actual);
    }
}
