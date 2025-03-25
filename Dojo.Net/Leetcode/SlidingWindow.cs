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
        if (s.Length < t.Length) return "";
        if (s.Equals(t)) return s;

        Dictionary<char, int> cmpFreq = GetCharCounts(t.ToCharArray());

        Dictionary<char, int> testFreq;
        if (s.Length == t.Length)
        {
            testFreq = GetCharCounts(s.ToCharArray());
            return CheckIfAllCharsExist(cmpFreq, testFreq) ? s : "";
        }

        PriorityQueue<Tuple<int, int>, int> minLengthsToWindows = new();
        int st = 0;
        Span<char> master = s.ToCharArray().AsSpan();
        for (int en = 0; en < master.Length; en++)
        {
            if (en + 1 - st < t.Length) continue;

            ReadOnlySpan<char> window = master[st..(en + 1)];
            // FIXME: Do not generate a new Dictionary for each substring window.
            // TODO: Instead, have a master dictionary and update the counts as the iteration proceeds.
            // TODO: Merge with L#52
            testFreq = GetCharCounts(window);
            
            
            if (!CheckIfAllCharsExist(cmpFreq, testFreq)) continue;

            while (en + 1 - st >= t.Length)
            {
                char yanked = s[st];
                if (testFreq[yanked] > 1) testFreq[yanked]--;
                else testFreq.Remove(yanked);

                st++;
                if (cmpFreq.TryGetValue(yanked, out int value) && (!testFreq.ContainsKey(yanked) || testFreq[yanked] < value)) break;
            }

            minLengthsToWindows.Enqueue(new Tuple<int, int>(st - 1, en + 1), en + 1 - (st - 1));
        }

        if (minLengthsToWindows.Count == 0) return string.Empty;

        Tuple<int, int> idxs = minLengthsToWindows.Dequeue();
        return s[idxs.Item1..idxs.Item2];
    }

    public static Dictionary<char, int> GetCharCounts(ReadOnlySpan<char> input)
    {
        Dictionary<char, int> charCounts = new(input.Length);

        foreach (char c in input)
        {
            if (charCounts.TryGetValue(c, out int _)) charCounts[c]++;
            else charCounts[c] = 1;
        }

        return charCounts;
    }

    private static bool CheckIfAllCharsExist(Dictionary<char, int> cmpFreq, Dictionary<char, int> testFreq)
    {
        foreach (var kvp in cmpFreq)
        {
            if (!testFreq.TryGetValue(kvp.Key, out int count) || count < kvp.Value)
            {
                return false;
            }
        }
        return true;
    }
}