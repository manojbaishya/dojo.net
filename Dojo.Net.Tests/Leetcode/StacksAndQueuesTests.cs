using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(StacksAndQueues))]
public class StacksAndQueuesTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;
    private readonly StacksAndQueues sut = new();

    [Theory]
    [InlineData(new int[] { 5, 10, -5 }, new int[] { 5, 10 })]
    [InlineData(new int[] { -2, -1, 1, 2 }, new int[] { -2, -1, 1, 2 })]
    [InlineData(new int[] { -2, -2, 1, -2 }, new int[] { -2, -2, -2 })]
    [InlineData(new int[] { 1, -2, -2, -2 }, new int[] { -2, -2, -2 })]
    public void AsteroidCollision(int[] input, int[] expected)
    {
        int[] actual = sut.AsteroidCollision(input);
        _logger.WriteLine($"Expected: [{string.Join(',', expected)}]");
        _logger.WriteLine($"Actual: [{string.Join(',', actual)}]");
        Assert.Equal(expected, actual);
    }
}
