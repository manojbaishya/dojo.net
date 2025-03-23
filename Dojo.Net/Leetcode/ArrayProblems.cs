using System;

namespace Dojo.Net.Leetcode;

public class ArrayProblems
{
    /// <summary>
    /// Variable Size Sliding Window solution.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MinSubArrayLen(int target, int[] nums) 
    {
        int minLength = int.MaxValue;

        int windowSum = 0;
        int start = 0;

        for (int end = 0; end < nums.Length; end++)
        {
            windowSum += nums[end];

            while(windowSum >= target)
            {
                windowSum -= nums[start];
                minLength = Math.Min(minLength, end + 1 - start);
                start++;
            }
        }

        return minLength != int.MaxValue ? minLength : 0;
    }
}
