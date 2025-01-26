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
    [InlineData(new int[] {2, 7, 11, 15}, 9, new int[] {0, 1})]
    [InlineData(new int[] {3, 2, 4}, 6, new int[] {1, 2})]
    [InlineData(new int[] {3, 3}, 6, new int[] {0, 1})]
    public void TestTwoSum(int[] inputArray, int inputTarget, int[] expected)
    {
        
        var twoSumSolution = new TwoSumSolution();
        int[] actual = twoSumSolution.TwoSum(inputArray, inputTarget);
        
        _logger.WriteLine(string.Join(",", actual));
        
        Assert.Equivalent(expected, actual);
    }
}