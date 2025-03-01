using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Dojo.Net;

public class App
{
    private static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run<App>();
    }

    [ParamsSource(nameof(GetListSizes))]
    public int Size;
    public static IEnumerable<int> GetListSizes()
    {
        int[] sizes = [50, 100, 200, 400, 800, 1600, 3200];
        foreach (int size in sizes) yield return size;
    }

    [Benchmark]
    public bool BenchmarkRuntimeAnalysisHasDuplicates()
    {
        IList<int> testSubject = [.. Enumerable.Range(0, Size)];
        return RuntimeAnalysis.HasDuplicates(testSubject);
    }

    [Benchmark]
    public bool BenchmarkRuntimeAnalysisHasDuplicatesWithSorting()
    {
        IList<int> testSubject = [.. Enumerable.Range(0, Size)];
        return RuntimeAnalysis.HasDuplicatesWithSorting(testSubject);
    }

    [Benchmark]
    public bool BenchmarkRuntimeAnalysisHasDuplicatesWithSets()
    {
        IList<int> testSubject = [.. Enumerable.Range(0, Size)];
        return RuntimeAnalysis.HasDuplicatesWithSets(testSubject);
    }

    [Benchmark]
    public bool BenchmarkRuntimeAnalysisHasDuplicatesWithSetLength()
    {
        IList<int> testSubject = [.. Enumerable.Range(0, Size)];
        return RuntimeAnalysis.HasDuplicatesWithSetLength(testSubject);
    }
}