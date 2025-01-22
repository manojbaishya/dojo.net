using Xunit;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using FluentAssertions;
using System.Numerics;

namespace Dojo.Net.Tests;

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


public class PolynomialTests(ITestOutputHelper logger)
{

    private readonly ITestOutputHelper logger = logger;

    [Fact]
    public void TestPolynomialToString()
    {
        Polynomial polynomial = new(1, 2, 3, 4, 5);
        var expectedPolynomial = "1 + 2x + 3x^2 + 4x^3 + 5x^4";
        var actualPolynomial = polynomial.ToString();

        logger.WriteLine($"Actual Polynomial is: '{actualPolynomial}'");

        actualPolynomial.Should().Be(expectedPolynomial, "because actualPolynomial is equal to expectedPolynomial.");
    }

    [Fact]
    public void TestPolynomialComputeFft() {
        Polynomial polynomial = new(6, 5, 8, 32);

        Complex[] actualFft = [new Complex(51, 0), new Complex(-2, -27), new Complex(-23, 0), new Complex(-2, 27)];
        Complex[] expectedFft = polynomial.ComputeFft();

        logger.WriteLine($"Actual Polynomial is: '{actualFft.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}")}'");

        logger.WriteLine($"Expected Polynomial is: '{expectedFft.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}")}'");
    }
}
