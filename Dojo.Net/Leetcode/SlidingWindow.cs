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
            if (window.Count > k) window.Remove(nums[i - k]);
        }

        return false;
    }

    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length) return string.Empty;
        if (s.Equals(t)) return s;

        Dictionary<char, int> cmpFreq = GetCharCounts(t);
        Dictionary<char, int> testFreq = new(UniqueCharCount(s));
        PriorityQueue<Tuple<int, int>, int> minLengthsToWindows = new();

        int start = 0;
        int missing = cmpFreq.Count;
        for (int end = 0; end < s.Length; end++)
        {
            char inserted = s[end];
            if (testFreq.TryGetValue(inserted, out int _)) testFreq[inserted]++;
            else testFreq[inserted] = 1;
            if (cmpFreq.TryGetValue(inserted, out int value) && testFreq.TryGetValue(inserted, out int cmpVal) && cmpVal == value) missing--;

            if (end + 1 - start < t.Length) continue;
            if (missing > 0) continue;
            

            while (missing == 0)
            {
                char yanked = s[start];
                
                if (testFreq[yanked] > 1) testFreq[yanked]--;
                else testFreq.Remove(yanked);
                
                if (cmpFreq.TryGetValue(yanked, out value) && !(testFreq.TryGetValue(yanked, out int cmpValue) && cmpValue >= value)) missing++;
                
                start++;
            }

            minLengthsToWindows.Enqueue(new Tuple<int, int>(start - 1, end + 1), end + 1 - (start - 1));
        }

        if (minLengthsToWindows.Count == 0) return string.Empty;

        Tuple<int, int> idxs = minLengthsToWindows.Dequeue();
        return s[idxs.Item1..idxs.Item2];
    }

    public static Dictionary<char, int> GetCharCounts(ReadOnlySpan<char> input)
    {
        int count = UniqueCharCount(input);
        Dictionary<char, int> charCounts = new(count);

        foreach (char c in input)
        {
            if (charCounts.TryGetValue(c, out int _)) charCounts[c]++;
            else charCounts[c] = 1;
        }

        return charCounts;
    }

    public static int UniqueCharCount(ReadOnlySpan<char> input)
    {
        Span<bool> seen = stackalloc bool[52];
        int uniqueCount = 0;

        foreach (char c in input)
        {
            int index = (c >= 'a') ? (c - 'a' + 26) : (c - 'A');
            if (!seen[index])
            {
                seen[index] = true;
                uniqueCount++;
            }
        }
        return uniqueCount;
    }
}