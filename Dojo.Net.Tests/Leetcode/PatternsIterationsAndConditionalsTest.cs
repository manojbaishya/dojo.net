using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(PatternsIterationsAndConditionals))]
public class PatternsIterationsAndConditionalsTest
{

    [Fact]
    public void NDimensionalForestBruteForce()
    {
        int n = 10;
        var sut = new PatternsIterationsAndConditionals();
        sut.NDimensionalForestBruteForce(n);
    }
    
    [Fact]
    public void NDimensionalForestCacheArray()
    {
        int n = 10;
        var sut = new PatternsIterationsAndConditionals();
        sut.NDimensionalForestCacheArray(n);
    }

    [Fact]
    public void NBy2DimensionalForest()
    {
        int n = 10;
        var sut = new PatternsIterationsAndConditionals();
        sut.NBy2DimensionalForest(n);
    }

    [Fact]
    public void NTriangle()
    {
        int n = 10;
        var sut = new PatternsIterationsAndConditionals();
        sut.NTriangle(n);
    }
    
    [Fact]
    public void NTriangleCached()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NTriangleCached(n);
    }
    
    [Fact]
    public void NTriangleRows()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NTriangleRows(n);
    }


}