using System;
using System.Collections.Generic;
using System.Linq;
using Dojo.Net.Leetcode;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Net.Tests.Leetcode;

[TestSubject(typeof(AmazonTransactionLogs))]
public class AmazonTransactionLogsTests(ITestOutputHelper logger)
{
    private readonly ITestOutputHelper _logger = logger;

    [Theory]
    [InlineData(new[] { "1 2 50", "1 7 70", "1 3 20", "2 2 17" }, 2, new[] { "1", "2" })]
    [InlineData(new[] { "9 7 50", "22 7 20", "33 7 50", "22 7 30" }, 3, new[] { "7" })]
    public void TestGetItemsInClosedContainers(string[] logs, int threshold, string[] expectedUsersExceedingThreshold)
    {
        var sut = new AmazonTransactionLogs();
        string[] actual = [.. sut.ProcessLogs(logs.ToList(), threshold)];

        _logger.WriteLine(string.Join(",", actual));

        Assert.Equivalent(expectedUsersExceedingThreshold, actual);
    }
}
