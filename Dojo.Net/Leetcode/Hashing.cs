using System.Collections.Generic;

namespace Dojo.Net.Leetcode;

public class Hashing
{
    public int[] CountFrequencies(int[] arr)
    {
        SortedDictionary<int, int> frequencies = [];

        for (int i = 0; i < arr.Length; i++)
        {
            if (!frequencies.TryAdd(arr[i], 1)) frequencies[arr[i]] += 1;
        }

        int[] freqArray = new int[arr.Length];
        foreach(int key in frequencies.Keys)
        {
            freqArray[key - 1] = frequencies[key];
        }

        return freqArray;
    }
}
