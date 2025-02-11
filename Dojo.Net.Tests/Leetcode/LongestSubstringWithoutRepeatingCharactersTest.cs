using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(LongestSubstringWithoutRepeatingCharactersSolution))]
public class LongestSubstringWithoutRepeatingCharactersTest(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("qrsvbspk", 5)]
    public void TestLengthOfLongestSubstring(string testString, int expectedLength)
    {
        LongestSubstringWithoutRepeatingCharactersSolution testedClass = new();
        int actualLength = testedClass.LengthOfLongestSubstring(testString);

        _logger.WriteLine($"expectedLength: {expectedLength}, actualLength: {actualLength}");

        Assert.Equal(expectedLength, actualLength);
    }
}