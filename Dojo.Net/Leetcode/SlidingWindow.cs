using System;

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

    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        // TODO: Optimize using sliding window
        for (int i = 0; i < nums.Length - k; i++)
        {
            for (int j = i + 1; j <= i + k; j++)
            {
                if (nums[i] == nums[j]) return true;
            }
        }
        return false;
    }
}
