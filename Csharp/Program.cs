using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Csharp;

public class Program
{
    private static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run<Program>();
    }

    [ParamsSource(nameof(GetListSizes))]
    public int Size;
    public static IEnumerable<int> GetListSizes()
    {
        foreach (int size in (IList<int>)[50, 100, 200, 400, 800, 1600, 3200]) yield return size;
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

public class CartItem
{
    public double Price;
}

public class RuntimeAnalysis
{
    public static bool HasDuplicates<T>(IList<T> list) where T : IEquatable<T>
    {
        int size = list.Count;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (i != j && list[i].Equals(list[j])) return true;
            }
        }
        return false;
    }

    public static bool HasDuplicatesWithSorting<T>(IList<T> list) where T : IEquatable<T>
    {
        int size = list.Count;
        IList<T> sortedList = [.. list.OrderBy(val => val)];
        for (int i = 0; i < sortedList.Count - 1; i++)
        {
            if (sortedList[i].Equals(sortedList[i + 1])) return true;
        }
        return false;
    }

    public static bool HasDuplicatesWithSets<T>(IList<T> list) where T : IEquatable<T>
    {
        HashSet<T> set = [];
        foreach (T item in list)
        {
            if (set.Contains(item)) return true;
            set.Add(item);
        }

        return false;
    }

    public static bool HasDuplicatesWithSetLength<T>(IList<T> list) where T : IEquatable<T>
    {
        HashSet<T> set = [.. list];
        return set.Count != list.Count;
    }
}