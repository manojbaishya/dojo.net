using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(ArrayProblems))]
public class ArrayProblemsTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;
    private readonly ArrayProblems sut = new();

    [Theory]
    [InlineData(7, new int[] {2,3,1,2,4,3}, 2)]
    [InlineData(4, new int[] {1, 4, 4}, 1)]
    [InlineData(11, new int[] {1,1,1,1,1,1,1,1}, 0)]
    public void LongestCommonPrefix(int target, int[] nums, int expected)
    {
        int actual = sut.MinSubArrayLen(target, nums);
        _logger.WriteLine($"Expected: {expected}, Actual: {actual}");
        Assert.Equal(expected, actual);
    }
}
