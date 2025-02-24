using System.Collections.Generic;

namespace Dojo.Net.Leetcode;

public enum Relation
{
    LessThan = -1,
    Contains = 0,
    GreaterThan = 1
}

public class TwoSumSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int c = target - nums[i];
            if (map.TryGetValue(c, out int j))
            {
                return [i, j];
            }
            map[nums[i]] = i;
        }
        return [];
    }
}