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
    [InlineData(7, new int[] { 2, 3, 1, 2, 4, 3 }, 2)]
    [InlineData(4, new int[] { 1, 4, 4 }, 1)]
    [InlineData(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 0)]
    public void LongestCommonPrefix(int target, int[] nums, int expected)
    {
        int actual = sut.MinSubArrayLen(target, nums);
        _logger.WriteLine($"Expected: {expected}, Actual: {actual}");
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[6] { 139, 395, 296, 492, 377, 473 }, new int[6] { 139, 296, 377, 395, 473, 492 })]
    [InlineData(new int[5] { 359, 266, 125, 318, 224 }, new int[5] { 125, 224, 266, 318, 359 })]
    [InlineData(new int[10] { 328, 182, 341, 327, 115, 384, 447, 210, 316, 220 }, new int[10] { 115, 182, 210, 220, 316, 327, 328, 341, 384, 447 })]
    [InlineData(new int[25] { 76088, 73640, 70858, 75035, 51858, 88499, 22543, 6648, 80422, 78931, 91252, 17044, 97663, 83138, 76228, 37233, 38384, 70984, 16304, 76902, 94159, 59994, 44607, 51800, 4264 }, new int[25] { 4264, 6648, 16304, 17044, 22543, 37233, 38384, 44607, 51800, 51858, 59994, 70858, 70984, 73640, 75035, 76088, 76228, 76902, 78931, 80422, 83138, 88499, 91252, 94159, 97663 })]
    [InlineData(new int[25] { 99140, 9327, 88279, 43779, 57763, 93010, 45764, 98581, 3000, 7322, 21898, 96719, 66520, 15489, 6124, 50053, 74645, 35177, 73757, 57436, 882, 61197, 81655, 2027, 91510 }, new int[25] { 882, 2027, 3000, 6124, 7322, 9327, 15489, 21898, 35177, 43779, 45764, 50053, 57436, 57763, 61197, 66520, 73757, 74645, 81655, 88279, 91510, 93010, 96719, 98581, 99140 })]
    public void MergeSort(int[] nums, int[] expected)
    {
        _logger.WriteLine($"Expected: [{string.Join(',', nums)}]");
        sut.MergeSort(nums, 0, nums.Length - 1);
        _logger.WriteLine($"Actual: [{string.Join(',', nums)}]");
        Assert.Equal(expected, nums);
    }

    [Theory]
    [InlineData(new int[10] { 101, 114, 330, 207, 220, 179, 188, 228, 415, 374 }, new int[10] { 101, 114, 179, 188, 207, 220, 228, 330, 374, 415 })]
    [InlineData(new int[6] { 139, 395, 296, 492, 377, 473 }, new int[6] { 139, 296, 377, 395, 473, 492 })]
    [InlineData(new int[5] { 359, 266, 125, 318, 224 }, new int[5] { 125, 224, 266, 318, 359 })]
    [InlineData(new int[10] { 328, 182, 341, 327, 115, 384, 447, 210, 316, 220 }, new int[10] { 115, 182, 210, 220, 316, 327, 328, 341, 384, 447 })]
    [InlineData(new int[25] { 76088, 73640, 70858, 75035, 51858, 88499, 22543, 6648, 80422, 78931, 91252, 17044, 97663, 83138, 76228, 37233, 38384, 70984, 16304, 76902, 94159, 59994, 44607, 51800, 4264 }, new int[25] { 4264, 6648, 16304, 17044, 22543, 37233, 38384, 44607, 51800, 51858, 59994, 70858, 70984, 73640, 75035, 76088, 76228, 76902, 78931, 80422, 83138, 88499, 91252, 94159, 97663 })]
    [InlineData(new int[25] { 99140, 9327, 88279, 43779, 57763, 93010, 45764, 98581, 3000, 7322, 21898, 96719, 66520, 15489, 6124, 50053, 74645, 35177, 73757, 57436, 882, 61197, 81655, 2027, 91510 }, new int[25] { 882, 2027, 3000, 6124, 7322, 9327, 15489, 21898, 35177, 43779, 45764, 50053, 57436, 57763, 61197, 66520, 73757, 74645, 81655, 88279, 91510, 93010, 96719, 98581, 99140 })]
    public void QuickSort(int[] nums, int[] expected)
    {
        _logger.WriteLine($"Expected: [{string.Join(',', expected)}]");
        sut.QuickSort(nums, 0, nums.Length - 1);
        _logger.WriteLine($"Actual: [{string.Join(',', nums)}]");
        Assert.Equal(expected, nums);
    }
}
