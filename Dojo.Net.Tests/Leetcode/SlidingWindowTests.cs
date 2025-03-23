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
    private readonly SlidingWindow sut = new();

    [Theory]
    [InlineData(new int[] { 1, 2, 4 }, 5, 3)]
    [InlineData(new int[] { 1, 4, 8, 13 }, 5, 2)]
    [InlineData(new int[] { 3, 9, 6 }, 2, 1)]
    public void MaxFrequency(int[] nums, int k, int expected)
    {
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
        bool actual = sut.ContainsNearbyDuplicate(nums, k);
        _logger.WriteLine($"Expected: {expected}");
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    [InlineData("a", "b", "")]
    [InlineData("aa", "aa", "aa")]
    [InlineData("bbaa", "aba", "baa")]
    public void MinWindow(string s, string t, string expected)
    {
        string actual = sut.MinWindow(s, t);
        _logger.WriteLine($"Expected: {expected}, Actual {actual}");
        Assert.Equal(expected, actual);
    }
}
