using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(OptimizingBoxWeights))]
public class OptimizingBoxWeightsTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(new[] { 3, 7, 5, 6, 2 }, new[] {6, 7})]
    public void TestMinimalHeaviestBox(int[] weights, int[] expectedMinimalHeaviestSubset)
    {
        var sut = new OptimizingBoxWeights();
        int[] actualMinimalHeaviestSubset = sut.MinimalHeaviestBox(weights);

        _logger.WriteLine(string.Join(",", actualMinimalHeaviestSubset));

        Assert.Equivalent(expectedMinimalHeaviestSubset, actualMinimalHeaviestSubset);
    }
}