using Xunit;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using FluentAssertions;

namespace Csharp.Tests;

public class CartItemTests(ITestOutputHelper logger)
{

    private readonly ITestOutputHelper logger = logger;

    [Fact]
    public void TestTotal()
    {
        IList<CartItem> cartItems = [new CartItem { Price = 20 }, new CartItem { Price = 30 }];

        var expectedTotalPrice = 50;
        var actualTotalPrice = cartItems.Sum(x => x.Price);

        logger.WriteLine($"Actual Total Price is: '{actualTotalPrice}'");

        actualTotalPrice.Should().Be(expectedTotalPrice, "because actualTotalPrice is equal to expectedTotalPrice.");
    }
}

public class RuntimeAnalysisTests(ITestOutputHelper logger)
{

    private readonly ITestOutputHelper logger = logger;

    [Fact]
    public void TestHasDuplicates()
    {
        IList<int> listHasDuplicates = [1, 2, 6, 3, 4, 5, 6, 7, 8];
        RuntimeAnalysis.HasDuplicates(listHasDuplicates).Should().BeTrue("because atleast '6' is a duplicate.");
        logger.WriteLine($"{nameof(listHasDuplicates)} returned true!");

        IList<int> listDoesNotHaveDuplicates = [1, 2, 3, 4];
        RuntimeAnalysis.HasDuplicates(listDoesNotHaveDuplicates).Should().BeFalse("because has no duplicates.");
        logger.WriteLine($"{nameof(listHasDuplicates)} returned false!");
    }
}