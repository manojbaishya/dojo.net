using System;

namespace Dojo.Net.Leetcode;

public enum Relation {
    LessThan = -1,
    EqualTo = 0,
    GreaterThan = 1
}

public class TwoSumSolution {
    public static int[] TwoSum(int[] nums, int target) {
        
        QuickSort(nums);
        (int hidx, Relation _) = BinarySearch(nums, target / 2);
        int i = hidx - 1, j = hidx + 1;
        while (i != 0 || j != nums.Length)
        {
            if (nums[i] + nums[j] == target) return [i, j];
            i--; j++;
        }

        return [0, 0];
    }

    public static (int, Relation) BinarySearch(int[] nums, int value) {
        (int i, int j) = (0, nums.Length);

        while(j - i > 1) {
            int midx = (j + i) / 2;
            if (value < nums[midx]) j = midx;
            else if (value > nums[midx]) i = midx;
            else return (midx, Relation.EqualTo);
        }

        if (i == 0) return (i, Relation.LessThan);
        if (j == nums.Length) return (i, Relation.GreaterThan);
        return (j, Relation.LessThan); 

    }

    public static void QuickSort(int[] nums, int lbound = 0, int rbound = default) {
        if (rbound == default) rbound = nums.Length;

        if (rbound - lbound > 1) {
            int midx = PivotAndPartition(nums, lbound, rbound);
            QuickSort(nums, lbound, midx);
            QuickSort(nums, midx + 1, rbound);
        }
    }

    public static int PivotAndPartition(int[] nums, int lbound, int rbound) {
        int pivot = Median(nums, lbound, rbound);
        (nums[pivot], nums[rbound - 1]) = (nums[rbound - 1], nums[pivot]);
        (int i, int j, pivot) = (lbound, rbound - 2, rbound - 1);

        while (i < j) {
            while(nums[i] < nums[pivot]) i++;
            while(i < j && nums[j] >= nums[pivot]) j--;
            if(i < j) (nums[i], nums[j]) = (nums[j], nums[i]); 
        }

        // i and j should become equal at this point
        if (nums[pivot] <= nums[i]) {
            (nums[pivot], nums[i]) = (nums[i], nums[pivot]);
            pivot = i;
        }

        return pivot;
    }

    public static int Median(int[] nums, int lbound, int rbound) {
        int midx = (lbound + (rbound - 1)) / 2;
        (int Ll, int Lm, int Lr) = (nums[lbound], nums[midx], nums[rbound]);

        if ((Ll <= Lm && Lm <= Lr) || (Ll >= Lm && Lm >= Lr)) return midx;
        else if ((Lm <= Ll && Ll <= Lr) || (Lm >= Ll && Ll >= Lr)) return lbound;
        else return rbound - 1;
    }
}