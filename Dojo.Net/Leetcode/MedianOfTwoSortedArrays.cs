using static System.Math;

namespace Dojo.Net.Leetcode;

public class MedianOfTwoSortedArraysSolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // S = Smaller array
        // B = Bigger array
        var (S, B) = nums1.Length <= nums2.Length ? (nums1, nums2) : (nums2, nums1);

        // Let M be the merged array = [..S, ..B]
        // Size of merged array is
        int MSize = S.Length + B.Length;

        // IMPORTANT: Median finding logic depends on whether M has even or odd count of elements
        bool isEven = MSize % 2 == 0;

        // INVARIANT: The median of the merged array divides it into a one and only one correct symmetry:
        //      50% count on the left partition and 50% on the right partition;
        // if isEven, then M == LeftPartitionSize x 2 (due to integer division),
        //      else !isEven, then M == LeftPartitionSize x 2 - 1 (M + 1 is even)
        //      so for odd sized M, LeftPartitionSize = RightPartionSize + 1, this influences the formula for
        //      finding median for odd sized M
        int LEFTPARTITIONSIZE = (MSize + 1) >> 1; // CONSTANT
        
        // Binary search to find the correct element count from S (left partition of S) 
        //      which goes into the left partition of M
        // Let SLCount = correct number of elements from S (left partition of S) 
        //      which goes into the left partition of M
        // Then BLCount = correct number of elements from B (left partition of B) 
        //      which goes into the left partition of M
        // Lemma: LeftPartitionSize (INVARIANT) = SLCount + BLCount;
        // Binary search to determine correct SLCount, over the smaller array to reduce time complexity
        int lowerBoundSLCount = 0, upperBoundSLCount = S.Length;

        while (lowerBoundSLCount <= upperBoundSLCount)
        {
            // Test element counts (also partition boundaries) of both S and B
            //      which goes into LeftPartition of M
            int testSLCount = (lowerBoundSLCount + upperBoundSLCount) >> 1;
            int testBLCount = LEFTPARTITIONSIZE - testSLCount;

            // Values for the above element counts
            int SLMAX = int.MinValue, BLMAX = int.MinValue;
            int SRMIN = int.MaxValue, BRMIN = int.MaxValue;

            // testSLCount is size, hence rightmost value in the Left Partition of S has index testSLCount - 1
            // Guard for
            if (testSLCount - 1 >= 0) SLMAX = S[testSLCount - 1];
            // Hence, leftmost value in the Right Partition of S has index testSLCount
            // Guard for
            if (testSLCount < S.Length) SRMIN = S[testSLCount];
            // testBLCount is size, hence rightmost value in the Left Partition of B has index testBLCount - 1
            // Guard for
            if (testBLCount - 1 >= 0) BLMAX = B[testBLCount - 1];
            // Hence, leftmost value in the Right Partition of B has index testBLCount
            // Guard for
            if (testBLCount < B.Length) BRMIN = B[testBLCount];

            // Binary search logic for the correct SLCount
            //      (and therefore, BLCount which is LEFTPARTITIONSIZE - SLCount)
            
            /* 
             * Iteration of partitionings to find the correct symmetry:
             * Rotate top (small) and bottom (big) arrays to arrive at the correct partitioning
             *      S0, S1, S2 ... S[testSLCount - 1] or SLMAX | SRMIN or S[testSLCount], S[testSLCount + 1], ... S[S.Length - 1]
             * B0, B1, B2, ....... B[testBLCount - 1] or BLMAX | BRMIN or B[testBLCount], B[testBLCount + 1], ...... B[B.Length - 1]
             */
             
            if (SLMAX <= BRMIN && BLMAX <= SRMIN)
            {
                return isEven ? CalculateMedian(SLMAX, BLMAX, SRMIN, BRMIN) : CalculateMedian(SLMAX, BLMAX);
            }

            // Counter Clockwise rotation, take higher count of elements from S and
            //      take lower count of elements from B to maintain Left Partition Size invariant and
            //      to maintain sorted order of M
            else if (BLMAX > SRMIN) lowerBoundSLCount = testSLCount + 1;
            // Clockwise rotation, take lower count of elements from S and
            //      take higher count of elements from B to maintain Left Partition Size invariant
            //      to maintain sorted order of M
            else if (SLMAX > BRMIN) upperBoundSLCount = testSLCount - 1;
        }

        // This case is never executed.
        return 0.0;
    }

    /// <summary>
    /// Calculate median of combined array M from S and B, when M.Length is even.
    /// </summary>
    /// <param name="SLMAX"></param>
    /// <param name="BLMAX"></param>
    /// <param name="SRMIN"></param>
    /// <param name="BRMIN"></param>
    /// <returns> A double valued median of combined array M from S and B, when M.Length is even.</returns>
    private static double CalculateMedian(int SLMAX, int BLMAX, int SRMIN, int BRMIN) 
        => (Max(SLMAX, BLMAX) + Min(SRMIN, BRMIN)) / 2.0;

    /// <summary>
    /// Calculate median of combined array M from S and B, when M.Length is odd.
    /// </summary>
    /// <param name="SLMAX"></param>
    /// <param name="BLMAX"></param>
    /// <param name="SRMIN"></param>
    /// <param name="BRMIN"></param>
    /// <returns> A double valued median of combined array M from S and B, when M.Length is odd.</returns>
    private static double CalculateMedian(int SLMAX, int BLMAX) 
        => Max(SLMAX, BLMAX);

}