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

            while(windowSum >= target)
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

        while(l <= mid && r <= right)
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

        while(l <= mid)
        {
            tmp.Add(arr[l]);
            l++;
        }

        while(r <= right)
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
        int pivot = MedianOfThree(arr, left, right);

        (arr[pivot], arr[left]) = (arr[left], arr[pivot]); 
        pivot = left;

        (int i, int j) = (left + 1, right);

        while(i < j)
        {
            while(arr[i] <= arr[pivot] && i < j) i++;
            while(arr[j] > arr[pivot] && j > i) j--;

            if (i < j) (arr[j], arr[i]) = (arr[i], arr[j]);
        }

        (arr[pivot], arr[i - 1]) = (arr[i - 1], arr[pivot]); 
        pivot = i - 1;

        return pivot;
        
    }

    private static int MedianOfThree(int[] arr, int left, int right)
    {
        if(right - left == 1) return arr[left] <= arr[right] ? left : right;
        
        int mid = left + (right - left) / 2;
        (int a, int b, int c) = (arr[left], arr[mid], arr[right]);
        
        if ((a <= b && b <= c) || (a >= b && b >= c)) return mid;
        if ((a <= c && c <= b) || (a >= c && c >= b)) return right;
        return left;
    }
}
