using System;
using System.Collections.Generic;

namespace Dojo.Net.Leetcode;

public class SlidingWindow
{
    // TODO: Implement int SlidingWindow.MaxFrequency(int[], int)
    // Leetcode problem 1838. Frequency of the Most Frequent Element
    // 
    public int MaxFrequency(int[] nums, int k)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Uses Set of fixed size to detect duplicates
    /// while scanning over the array only once.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        HashSet<int> window = new(k + 1);

        for (int i = 0; i < nums.Length; i++)
        {
            if (window.Contains(nums[i])) return true;

            window.Add(nums[i]);

            if (window.Count > k)
            {
                window.Remove(nums[i - k]);
            }
        }

        return false;
    }

    public string MinWindow(string s, string t) 
    {
        // Validation Checks
        if (!new HashSet<char>(s).IsSupersetOf(new HashSet<char>(t))) return string.Empty;
        if (s.Equals(t)) return s;

        PriorityQueue<Tuple<int, int>, int> minlengthIndices = new();
        Dictionary<char, int> window = [];
        int minLength = int.MaxValue;

        int start = 0;
        for (int end = 0; end < s.Length; end++)
        {
            if(!window.TryAdd(s[end], 1)) window[s[end]] += 1;

            HashSet<char> keySet = [.. window.Keys];

            while (keySet.IsSupersetOf(t))
            {
                minLength = Math.Min(minLength, end + 1 - start);
                if (window[s[start]] > 1) window[s[start]]--;
                else window.Remove(s[start]);
                keySet = [.. window.Keys];
                start++;
            }

            minlengthIndices.Enqueue(new Tuple<int, int>(start - 1, end), minLength);
        }

        Tuple<int, int> substringMatch = minlengthIndices.Dequeue();

        string substring = s[substringMatch.Item1..(substringMatch.Item2 + 1)];
        return substring.Length >= t.Length ? substring : string.Empty;
    }
}
