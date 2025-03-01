using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Net;

public static class RuntimeAnalysis
{
    public static bool HasDuplicates<T>(IList<T> list) where T : IEquatable<T>
    {
        int size = list.Count;

        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < i; j++)
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
        for (var i = 0; i < sortedList.Count - 1; i++)
        {
            if (sortedList[i].Equals(sortedList[i + 1])) return true;
        }
        return false;
    }

    public static bool HasDuplicatesWithSets<T>(IList<T> list) where T : IEquatable<T>
    {
        HashSet<T> set = [];
        return list.Any(item => !set.Add(item));
    }

    public static bool HasDuplicatesWithSetLength<T>(IList<T> list) where T : IEquatable<T>
    {
        var set = list.ToHashSet();
        return set.Count != list.Count;
    }
}