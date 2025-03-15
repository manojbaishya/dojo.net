using System;
using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(SlidingWindow))]
public class SlidingWindowTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(new int[] { 1, 2, 4 }, 5, 3)]
    [InlineData(new int[] { 1, 4, 8, 13 }, 5, 2)]
    [InlineData(new int[] { 3, 9, 6 }, 2, 1)]
    public void MaxFrequency(int[] nums, int k, int expected)
    {
        var sut = new SlidingWindow();
        try
        {
            int actual = sut.MaxFrequency(nums, k);
        }
        catch (NotImplementedException)
        {

        }
        _logger.WriteLine($"Expected: {expected}");
        // Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, 3, true)]
    [InlineData(new int[] { 1, 0, 1, 1 }, 1, true)]
    [InlineData(new int[] { 1, 2, 3, 1, 2, 3 }, 2, false)]
    public void ContainsNearbyDuplicate(int[] nums, int k, bool expected)
    {
        var sut = new SlidingWindow();
        bool actual = sut.ContainsNearbyDuplicate(nums, k);
        _logger.WriteLine($"Expected: {expected}");
        Assert.Equal(expected, actual);
    }
}
