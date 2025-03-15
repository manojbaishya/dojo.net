using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(Hashing))]
public class HashingTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(new int[] {2, 3, 2, 3, 5}, new int[] {0, 2, 2, 0, 1})]
    [InlineData(new int[] {3, 3, 3, 3}, new int[] {0, 0, 4, 0})]
    [InlineData(new int[] {1}, new int[] {1})]
    public void PrintStringNTimes(int[] input, int[] expected)
    {
        var sut = new Hashing();
        int[] actual = sut.CountFrequencies(input);

        Assert.Equivalent(expected, actual);
    }
}
