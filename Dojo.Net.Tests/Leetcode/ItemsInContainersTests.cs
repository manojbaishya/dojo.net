using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;
namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(ItemsInContainers))]
public class ItemsInContainersTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData("|**|*|*", new[] {1, 1}, new[] {5, 6}, new[] {2, 3})]
    public void TestGetItemsInClosedContainers(string compartments, int[] startIndices, int[] endIndices, int[] expectedItems)
    {
        var sut = new ItemsInContainers();
        int[] actualItems = sut.GetItemsInClosedContainers(compartments, startIndices, endIndices);

        _logger.WriteLine($"Expected Items: {string.Join(", ", expectedItems)}, Actual Items: {string.Join(", ", actualItems)}");

        Assert.Equivalent(expectedItems, actualItems);
    }
}
