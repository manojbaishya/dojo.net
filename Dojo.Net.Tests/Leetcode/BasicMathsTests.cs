using Dojo.Net.Leetcode;

using JetBrains.Annotations;

using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(BasicMaths))]
public class BasicMathsTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(12, 2)]
    public void TestEvenlyDivides(int number, int expected)
    {
        var sut = new BasicMaths();
        int actual = sut.EvenlyDivides(number);

        _logger.WriteLine($"Expected: {expected}");
        _logger.WriteLine($"Actual: {actual}");

        Assert.Equal(expected, actual);
    }
}
