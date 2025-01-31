namespace Dojo.Net.Leetcode;

public class MedianOfTwoSortedArraysSolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double medianNums1 = nums1.Length > 0 ? FindMedianSortedArray(nums1) : 0;
        double medianNums2 = nums2.Length > 0 ? FindMedianSortedArray(nums2) : 0;
        
        return Median(medianNums1, medianNums2);
    }
    
    private static double Median(double median1, double median2)
    {
        if (median1 == 0) return median2;
        else if (median2 == 0) return median1;
        else return (median1 + median2) / 2.0;
    }
    private static double FindMedianSortedArray(int[] A)
    {
        int k = A.Length;
        double median = 0;
        if (k % 2 != 0)
        {
            int midx = k / 2;
            median = A[midx];
        }
        else if (k % 2 == 0)
        {
            int midx = k / 2;
            double medianX2 = A[midx - 1] + A[midx];
            median = medianX2 / 2;
        }

        return median;
    }
}