using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(EasyProblems))]
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
    [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
    [InlineData(new string[] { "dog", "racecar", "car" }, "")]
    public void LongestCommonPrefix(string[] input, string expected)
    {
        string actual = sut.LongestCommonPrefix(input);
        _logger.WriteLine($"Expected: {expected}, Actual: {actual}");
        Assert.Equal(expected, actual);
    }



    [Theory]
    [InlineData(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
    public void MergeSortedArrays(int[] input1, int m, int[] input2, int n, int[] expected)
    {
        sut.MergeSortedArrays(input1, m, input2, n);
        Assert.Equivalent(input1, expected);
    }
}
