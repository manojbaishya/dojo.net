using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(MedianOfTwoSortedArraysSolution))]
public class MedianOfTwoSortedArraysTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
    public void TestFindMedianSortedArrays(int[] inputArr1, int[] inputArr2, double expectedMedian)
    {
        var sut = new MedianOfTwoSortedArraysSolution();
        double actualMedian = sut.FindMedianSortedArrays(inputArr1, inputArr2);

        _logger.WriteLine($"Expected Median: {expectedMedian}, Actual Median: {actualMedian}");

        Assert.Equal(expectedMedian, actualMedian);
    }
}
