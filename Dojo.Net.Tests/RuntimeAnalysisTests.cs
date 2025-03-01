using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using FluentAssertions;

namespace Dojo.Net.Tests;

public class RuntimeAnalysisTests(ITestOutputHelper logger)
{
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