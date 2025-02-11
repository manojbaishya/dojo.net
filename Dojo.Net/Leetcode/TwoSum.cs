using System;
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

    public int[] TwoSumTodo(int[] nums, int target)
    {
        int iOrg, jOrg;
        if (target == 0)
        {
            (_, Relation zrelation) = BinarySearch(nums, 0);
            if (zrelation == Relation.Contains)
            {
                (iOrg, jOrg) = FindIndices(nums, 0, 0);
                return [iOrg, jOrg];
            }
        }

        var numsBackup = new int[nums.Length];
        Array.Copy(nums, numsBackup, nums.Length);
        
        QuickSort(nums);
        int targetBisect = target / 2;
        (int hidx, Relation relation) = BinarySearch(nums, targetBisect);

        (int i, int j) = InitializeMovingPointers(nums, target, targetBisect, hidx, relation);

        do
        {
            if (nums[i] + nums[j] == target)
            {
                if (nums[i] == nums[j])
                {
                    (iOrg, jOrg) = FindIndices(numsBackup, nums[i], nums[i]);
                }
                else
                {
                    (iOrg, jOrg) = FindIndices(numsBackup, nums[i], nums[j]);
                }

                return [iOrg, jOrg];
            }

            i--;
            j++;
        } while (i != 0 && j != nums.Length - 1);

        return [0, 0];
    }

    private static (int i, int j) InitializeMovingPointers(int[] nums, int target, int targetBisect,
        int hidx, Relation relation)
    {
        int i, j;
        if (relation == Relation.Contains)
        {
            if (targetBisect * 2 == target)
            {
                if (hidx != nums.Length - 1 && nums[hidx] == nums[hidx + 1])
                {
                    i = hidx;
                    j = hidx + 1;
                }
                else if (hidx != 0 && nums[hidx - 1] == nums[hidx])
                {
                    i = hidx - 1;
                    j = hidx;
                }
                else
                {
                    i = hidx - 1;
                    j = hidx + 1;
                }
            }
            else
            {
                i = hidx;
                j = hidx + 1;
            }
        }
        else
        {
            i = hidx - 1;
            j = hidx;
        }

        return (i, j);
    }
    
    private static (int, int) FindIndices(int[] unsortedArray, int val1, int val2)
    {
        int firstIdx = -1;
        for (int secondIdx = 0; secondIdx < unsortedArray.Length; secondIdx++)
        {
            if (unsortedArray[secondIdx] == val1 || unsortedArray[secondIdx] == val2)
            {
                if (firstIdx == -1)
                    firstIdx = secondIdx;
                else
                    return (firstIdx, secondIdx);
            }
        }

        return (-1, -1);
    }
    
    private static (int, Relation) BinarySearch(int[] nums, int value)
    {
        (int i, int j) = (0, nums.Length);
        int midx = (j + i) / 2;

        int delta = j - i;
        while (delta > 1)
        {
            midx = (j + i) / 2;
            if (value == nums[midx]) return (midx, Relation.Contains);
            if (value < nums[midx])
            {
                j = midx;
                delta = j - i;
            }
            else if (value > nums[midx])
            {
                i = midx;
                delta = j - i;
            }
        }

        switch (delta)
        {
            case 1 when value == nums[midx]:
                return (midx, Relation.Contains);
            case 1 when value == nums[i]:
                return (i, Relation.Contains);
            case 1 when value == nums[j]:
                return (j, Relation.Contains);
        }

        if (i == 0 && value < nums[i]) return (i, Relation.LessThan);
        if (j == nums.Length && value > nums[^1]) return (j - 1, Relation.GreaterThan);
        return (j, Relation.LessThan);
    }

    private static bool IsSorted(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1]) return false;
        }
        return true;
    }

    private static void QuickSort(int[] nums, int lbound = 0, int rbound = 0)
    {
        if (IsSorted(nums)) return;
        if (rbound == 0) rbound = nums.Length;
        if (rbound - lbound <= 1) return;

        int midx = PivotAndPartition(nums, lbound, rbound);
        QuickSort(nums, lbound, midx);
        QuickSort(nums, midx + 1, rbound);
    }

    private static int PivotAndPartition(int[] nums, int lbound, int rbound)
    {
        int pivot = Median(nums, lbound, rbound);
        (nums[pivot], nums[rbound - 1]) = (nums[rbound - 1], nums[pivot]);
        (int i, int j, pivot) = (lbound, rbound - 2, rbound - 1);

        while (i < j)
        {
            while (nums[i] < nums[pivot]) i++;
            while (i < j && nums[j] >= nums[pivot]) j--;
            if (i < j) (nums[i], nums[j]) = (nums[j], nums[i]);
        }

        // i and j should become equal at this point
        if (nums[pivot] <= nums[i])
        {
            (nums[pivot], nums[i]) = (nums[i], nums[pivot]);
            pivot = i;
        }

        return pivot;
    }

    private static int Median(int[] nums, int lbound, int rbound)
    {
        int midx = (lbound + (rbound - 1)) / 2;
        (int ll, int lm, int lr) = (nums[lbound], nums[midx], nums[rbound - 1]);

        if ((ll <= lm && lm <= lr) || (ll >= lm && lm >= lr)) return midx;
        else if ((lm <= ll && ll <= lr) || (lm >= ll && ll >= lr)) return lbound;
        else return rbound - 1;
    }
}