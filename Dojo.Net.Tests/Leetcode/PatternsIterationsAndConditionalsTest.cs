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

    [Fact]
    public void Seeding()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.Seeding(n);
    }
    
    [Fact]
    public void NNumberTriangle()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NNumberTriangle(n);
    }
    
    [Fact]
    public void NStarTriangle()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NStarTriangle(n);
    }
    
    [Fact]
    public void NStarTriangleReversed()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NStarTriangleReversed(n);
    }
    
    [Fact]
    public void NStarTriangleDouble()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NStarTriangleDouble(n);
    }
    
    [Fact]
    public void NStarTriangleDoubleOneSided()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NStarTriangleDoubleOneSided(n);
    }
    
    [Fact]
    public void NTriangleBinary()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.NTriangleBinary(n);
    }
    
    [Fact]
    public void McDonalds()
    {
        int n = 9;
        var sut = new PatternsIterationsAndConditionals();
        sut.McDonalds(n);
    }
}