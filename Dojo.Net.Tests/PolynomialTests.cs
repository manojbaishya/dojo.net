using System.Linq;
using System.Numerics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests;

public class PolynomialTests(ITestOutputHelper logger)
{
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