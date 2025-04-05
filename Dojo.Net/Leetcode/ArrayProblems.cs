using System;
using System.Collections.Generic;
using System.Linq;

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
        int pivot = MedianOfThree(arr, left, right);
        // int pivot = left;

        (arr[left], arr[pivot]) = (arr[pivot], arr[left]);
        pivot = left;

        (int i, int j) = (left, right);
        while (i < j)
        {
            while (arr[i] <= arr[pivot] && i < right) i++;
            while (arr[j] > arr[pivot] && j > left) j--;

            if (i < j) (arr[j], arr[i]) = (arr[i], arr[j]);
        }

        if (arr[pivot] >= arr[j])
        {
            (arr[left], arr[j]) = (arr[j], arr[left]);
            pivot = j;
        }

        return pivot;
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

    public int Largest(List<int> arr)
    {
        int max = int.MinValue;
        for (int i = 0; i < arr.Count; i++) if (arr[i] >= max) max = arr[i];
        return max;
    }

    public int GetSecondLargest(int[] arr)
    {
        int max = int.MinValue;
        int midx = -1;
        for (int i = 0; i < arr.Length; i++) if (arr[i] >= max) (midx, max) = (i, arr[i]);

        (arr[0], arr[midx]) = (arr[midx], arr[0]);

        int secMax = int.MinValue;
        for (int i = 1; i < arr.Length; i++) if (arr[i] != max && arr[i] >= secMax) (_, secMax) = (i, arr[i]);

        return secMax != int.MinValue ? secMax : -1;
    }

    public bool CheckSortAndRotation(int[] nums)
    {
        int troughs = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i + 1] >= nums[i]) continue;
            else troughs++;
            if (troughs > 1) break;
        }

        if (troughs == 0) return true;
        if (troughs == 1 && nums[^1] <= nums[0]) return true;
        return false;
    }

    public int RemoveDuplicates(int[] nums)
    {
        int j = 0;
        List<int> indices = new(nums.Length) { 0 };
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[j] != nums[i])
            {
                indices.Add(i);
                j = i;
            }
        }

        for (int k = 0; k < indices.Count; k++)
        {
            nums[k] = nums[indices[k]];
        }

        return indices.Count;
    }

    public int RemoveDuplicates2(int[] nums)
    {
        int i = 0, j = 0;
        while (i < nums.Length)
        {
            if (nums[i] != nums[j])
            {
                j++;
                nums[j] = nums[i];
            }
            i++;
        }

        return j + 1;
    }

    public void Rotate(int[] nums, int k)
    {
        int m = k;
        if (k >= nums.Length) m = k % nums.Length;
        int[] tmp = new int[m];
        int N = nums.Length;
        for (int i = N - m; i < N; i++)
        {
            tmp[i - (N - m)] = nums[i];
        }

        for (int i = N - m - 1; i >= 0; i--)
        {
            nums[i + m] = nums[i];
        }

        for (int i = 0; i < m; i++)
        {
            nums[i] = tmp[i];
        }
    }

    public void Rotate2(int[] nums, int k)
    {
        int N = nums.Length;
        int m = k;
        if (k >= N) m = k % N;

        Reverse(nums, 0, N - 1);
        Reverse(nums, 0, m - 1);
        Reverse(nums, m, N - 1);
    }

    private static void Reverse(int[] nums, int l, int r)
    {
        int left = l, right = r;
        while (left < right)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
            left++;
            right--;
        }
    }


    public void MoveZeroes(int[] nums)
    {
        int i = 0, j = 0;
        while (i < nums.Length)
        {
            if (nums[i] != 0)
            {
                nums[j] = nums[i];
                j++;
            }
            i++;
        }

        for (int k = j; k < nums.Length; k++)
        {
            nums[k] = 0;
        }
    }

    public bool LinearSearch(int[] arr, int k)
    {
        for (int i = 0; i < arr.Length; i++) if (arr[i] == k) return true;
        return false;
    }

    public int[] FindUnion(int[] a, int[] b) => [.. new HashSet<int>([.. a, .. b]).Order()];

    public int MissingNumber(int[] nums)
    {
        int N = nums.Length;
        int cmpSum = N * (N + 1) / 2;
        int actualSum = 0;
        for (int i = 0; i < nums.Length; i++) actualSum += nums[i];
        return cmpSum - actualSum;
    }

    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int S = 0;
        int L = 0;
        for (int end = 0; end < nums.Length; end++)
        {
            if (nums[end] == 1) L++;
            else L = 0;
            if (L != 0) S = Math.Max(S, L);
        }

        return S;
    }

    public int SingleNumber(int[] nums)
    {
        int res = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            res ^= nums[i];
        }

        return res;
    }

    public int LongestSubarraySum(int[] arr, int k)
    {
        int maxLength = int.MinValue;
        int sum = 0;

        int start = 0;
        for (int end = 0; end < arr.Length; end++)
        {
            sum += arr[end];

            while (sum == k)
            {
                maxLength = Math.Max(maxLength, end + 1 - start);
                sum -= arr[start];
                start++;
            }
        }

        return maxLength != int.MinValue ? maxLength : 0;
    }

    public int LongestSubarraySumPrefix(int[] arr, int k)
    {
        int[] sums = new int[arr.Length + 1];

        for (int i = 0; i < arr.Length; i++)
            sums[i + 1] = sums[i] + arr[i];

        Dictionary<int, int> prefixSumMap = new Dictionary<int, int>();
        int maxLength = 0;

        for (int j = 0; j < arr.Length; j++)
        {
            int currentSum = sums[j + 1];

            if (currentSum == k)
                maxLength = Math.Max(maxLength, j + 1);

            if (prefixSumMap.ContainsKey(currentSum - k))
                maxLength = Math.Max(maxLength, j - prefixSumMap[currentSum - k]);

            if (!prefixSumMap.ContainsKey(currentSum))
                prefixSumMap[currentSum] = j;
        }

        return maxLength;
    }

    public int[] TwoSum2(int[] nums, int target)
    {
        Dictionary<int, int> map = new(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(target - nums[i])) return [map[target - nums[i]], i];
            map.TryAdd(nums[i], i);
        }

        return [-1, -1];
    }

    public void SortColors(int[] nums)
    {
        int red = 0, white = 0, blue = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            switch (nums[i])
            {
                case 0:
                    red++;
                    break;
                case 1:
                    white++;
                    break;
                case 2:
                    blue++;
                    break;
                default:
                    continue;
            }
        }

        int j = 0;
        while (j < red)
        {
            nums[j] = 0;
            j++;
        }
        while (j < red + white)
        {
            nums[j] = 1;
            j++;
        }
        while (j < red + white + blue)
        {
            nums[j] = 2;
            j++;
        }
    }

    public void SortColorsDutchNationalFlag(int[] nums)
    {
        int left = 0, mid = 0, right = nums.Length - 1;

        while (mid <= right)
        {
            if (nums[mid] == 0)
            {
                (nums[left], nums[mid]) = (nums[mid], nums[left]);
                left++;
                mid++;
            }
            else if (nums[mid] == 1)
            {
                mid++;
            }
            else
            {
                (nums[right], nums[mid]) = (nums[mid], nums[right]);
                right--;
            }
        }
    }


    public int MajorityElement(int[] nums)
    {
        Dictionary<int, int> freq = new(nums.Length);
        for (int i = 0; i < nums.Length; i++) if (!freq.TryAdd(nums[i], 1)) freq[nums[i]]++;
        foreach (KeyValuePair<int, int> pair in freq) if (pair.Value > (nums.Length / 2)) return pair.Key;
        return default;
    }

    public int MajorityElementMoore(int[] nums)
    {
        int element = default, count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (count == 0) element = nums[i];

            if (nums[i] == element) count++;
            else count--;
        }

        if (count == 0) return default;

        int freq = 0;
        for (int i = 0; i < nums.Length; i++) if (nums[i] == element) freq++;

        if (freq > nums.Length / 2) return element;
        else return default;
    }

    public int MaxSubArraySumKadane(int[] nums)
    {
        int sum = 0, maxSum = int.MinValue;
        int start = -1, subStart = -1, subEnd = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            if (sum > maxSum)
            {
                maxSum = sum;
                subStart = start;
                subEnd = i;
            }

            if (sum < 0) sum = 0;
        }

        return maxSum != int.MinValue ? maxSum : 0;
    }

    public int MaxProfit(int[] prices)
    {
        int minBuy = prices[0];
        int profit = 0;
        int checkProfit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            checkProfit = prices[i] - minBuy;
            profit = Math.Max(checkProfit, profit);
            minBuy = Math.Min(prices[i], minBuy);
        }

        return profit;
    }

    public int[] RearrangeArrayAlternateSigns(int[] nums)
    {
        int[] pos = new int[nums.Length / 2];
        int[] neg = new int[nums.Length / 2];

        int j = 0, k = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                pos[k] = nums[i];
                k++;
            }
            else
            {
                neg[j] = nums[i];
                j++;
            }

        }

        for (int i = 0; i < nums.Length / 2; i++)
        {
            nums[2 * i] = pos[i];
            nums[2 * i + 1] = neg[i];
        }

        return nums;
    }

    public void NextPermutation(int[] nums)
    {
        int N = nums.Length;

        int k = N - 2;
        while (k >= 0 && nums[k] >= nums[k + 1]) k--;

        if (k == -1)
        {
            Reverse(nums, 0, N - 1);
            return;
        }

        int l = N - 1;
        while (l >= 0 && nums[k] >= nums[l]) l--;

        (nums[l], nums[k]) = (nums[k], nums[l]);

        Reverse(nums, k + 1, N - 1);
    }

    public List<int> Leaders(int[] arr)
    {
        List<int> l = [];
        int N = arr.Length;

        int max = 0;
        for (int i = N - 1; i >= 0; i--)
        {
            if (arr[i] >= max) l.Add(arr[i]);

            max = Math.Max(max, arr[i]);
        }

        l.Reverse();

        return l;
    }

    public int LongestConsecutive(int[] nums) 
    {
        if (nums.Length == 0) return 0;
        
        HashSet<int> ints = [.. nums];
        
        int max = int.MinValue;
        int cnt = 0;
        foreach(int num in ints)
        {
            if (ints.Contains(num - 1)) continue;

            int nextNum = num;
            while(ints.Contains(nextNum))
            {
                cnt++;
                nextNum++;
            }

            max = Math.Max(max, cnt);
            cnt = 0;
        }

        return max;
    }

}
