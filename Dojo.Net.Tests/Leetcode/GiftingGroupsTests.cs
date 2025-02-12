using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(GiftingGroups))]
public class GiftingGroupsTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(new[] { "1100", "1110", "0110", "0001" }, 2)]
    [InlineData(new[] { "10000", "01000", "00100", "00010", "00001" }, 5)]
    public void TestCountGroups(string[] related, int expectedGroupCount)
    {
        var sut = new GiftingGroups();
        int actual = sut.CountGroupsDFS([.. related]);
        _logger.WriteLine($"DFS Expected: {expectedGroupCount}, Actual: {actual}");
        Assert.Equal(expectedGroupCount, actual);

        actual = sut.CountGroupsBFS([.. related]);
        _logger.WriteLine($"BFS Expected: {expectedGroupCount}, Actual: {actual}");
        Assert.Equal(expectedGroupCount, actual);
    }
}