using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests;

public class XunitMockClassTests(ITestOutputHelper logger)
{
    [Fact]
    public void TestLinqSum()
    {
        IList<XunitMockClass> cartItems = [new() { Price = 20 }, new() { Price = 30 }];

        const int expectedTotalPrice = 50;
        double actualTotalPrice = cartItems.Sum(x => x.Price);

        logger.WriteLine($"Actual Total Price is: '{actualTotalPrice}'");

        actualTotalPrice.Should().Be(expectedTotalPrice, "because actualTotalPrice is equal to expectedTotalPrice.");
    }
}