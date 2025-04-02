using System;
using System.Collections.Generic;

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

            while (windowSum >= target)
            {
                windowSum -= nums[start];
                minLength = Math.Min(minLength, end + 1 - start);
                start++;
            }
        }

        return minLength != int.MaxValue ? minLength : 0;
    }

    public void MergeSort(int[] arr, int left, int right)
    {
        if (left == right) return;
        int mid = (left + right) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        MergeSubarrays(arr, left, mid, right);
    }

    private static void MergeSubarrays(int[] arr, int left, int mid, int right)
    {
        int l = left;
        int r = mid + 1;

        List<int> tmp = new(right + 1 - left);

        while (l <= mid && r <= right)
        {
            if (arr[l] <= arr[r])
            {
                tmp.Add(arr[l]);
                l++;
            }
            else
            {
                tmp.Add(arr[r]);
                r++;
            }
        }

        while (l <= mid)
        {
            tmp.Add(arr[l]);
            l++;
        }

        while (r <= right)
        {
            tmp.Add(arr[r]);
            r++;
        }

        for (int i = left; i <= right; i++)
        {
            arr[i] = tmp[i - left];
        }
    }


    public void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = PartitionByPivot(arr, left, right);

            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }

    private static int PartitionByPivot(int[] arr, int left, int right)
    {
        // int pivot = MedianOfThree(arr, left, right);
        int pivot = left;

        (int i, int j) = (left, right);
        while (i < j)
        {
            while (i < right && arr[i] <= arr[pivot]) i++;
            while (j > left && arr[j] > arr[pivot]) j--;

            if (i < j) (arr[j], arr[i]) = (arr[i], arr[j]);
        }

        (arr[left], arr[j]) = (arr[j], arr[left]);

        return j;
    }

    private static int MedianOfThree(int[] arr, int left, int right)
    {
        if (right - left == 1) return arr[left] <= arr[right] ? left : right;

        int mid = left + (right - left) / 2;
        int a = arr[left], b = arr[mid], c = arr[right];

        if ((a > b) ^ (a > c)) return left;
        if ((b < a) ^ (b < c)) return mid;
        return right;
    }
}
