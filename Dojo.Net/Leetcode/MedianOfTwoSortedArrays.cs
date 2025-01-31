using System;

namespace Dojo.Net.Leetcode;

public class MedianOfTwoSortedArraysSolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {

        var (ArrSmall, ArrLarge) = nums1.Length < nums2.Length ? (nums1, nums2) : (nums2, nums1);

        int totalSize = ArrSmall.Length + ArrLarge.Length;
        int midSize = totalSize / 2;
        int leftPtr = 0, rightPtr = ArrSmall.Length - 1;

        while (true)
        {
            int i = (leftPtr + rightPtr) >> 1;
            int j = midSize - i - 2;

            int ArrSmallLeftMax = i >= 0 ? ArrSmall[i] : int.MinValue;
            int ArrLargeRightMin = j + 1 < ArrLarge.Length ? ArrLarge[j + 1] : int.MaxValue;

            int ArrLargeLeftMax = j >= 0 ? ArrLarge[j] : int.MinValue;
            int ArrSmallRightMin = i + 1 < ArrSmall.Length ? ArrSmall[i + 1] : int.MaxValue;

            if (ArrSmallLeftMax <= ArrLargeRightMin && ArrLargeLeftMax <= ArrSmallRightMin)
            {
                if (totalSize % 2 != 0)
                    return Math.Min(ArrSmallRightMin, ArrLargeRightMin);
                else
                    return (Math.Max(ArrSmallLeftMax, ArrLargeLeftMax) + Math.Min(ArrSmallRightMin, ArrLargeRightMin)) / 2.0;
            }
            else if (ArrSmallLeftMax > ArrLargeRightMin) rightPtr = i - 1;
            else leftPtr = i + 1;
        }
    }

}