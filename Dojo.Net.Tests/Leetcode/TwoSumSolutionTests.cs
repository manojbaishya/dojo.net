using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(TwoSumSolution))]
public class TwoSumSolutionTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 3 }, 6, new[] { 0, 2 })]
    [InlineData(new[] { 0, 4, 3, 0 }, 0, new[] { 0, 3 })]
    [InlineData(new[] { -3, 4, 3, 90 }, 0, new[] { 0, 2 })]
    [InlineData(new[] { -1, -2, -3, -4, -5 }, -8, new[] { 2, 4 })]
    [InlineData(new[] { -10, -1, -18, -19 }, -19, new[] { 1, 2 })]
    public void TestTwoSum(int[] inputArray, int inputTarget, int[] expected)
    {
        var twoSumSolution = new TwoSumSolution();
        int[] actual = twoSumSolution.TwoSum(inputArray, inputTarget);

        _logger.WriteLine(string.Join(",", actual));

        Assert.Equivalent(expected, actual);
    }
}