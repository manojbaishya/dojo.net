using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp;

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

public class Polynomials {

}