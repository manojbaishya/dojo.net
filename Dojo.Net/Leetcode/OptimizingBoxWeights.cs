using System;
using System.Linq;

namespace Dojo.Net.Leetcode;

public class OptimizingBoxWeights
{
    public int[] MinimalHeaviestBox(int[] weights) {
        // Sort weights in descending order - O(nlgn)
        Array.Sort(weights, (a, b) => b.CompareTo(a));
        
        // Dynamic Programming approach
        int totalSum = weights.Sum();
        int minSizeSum = weights[0];
        int complementSum = totalSum - weights[0];
        
        int minLength = weights.Length;
        if (minSizeSum > complementSum)
        {
            minLength = 1;
        }
        else
        {
            for (int k = 1; k < weights.Length; k++)
            {
                minSizeSum += weights[k];
                complementSum = totalSum - minSizeSum;

                if (minSizeSum > complementSum)
                {
                    minLength = k + 1;
                    break;
                }
            }
        }

        int[] results = new int[minLength];
        for (int j = minLength - 1, m = 0; j >= 0; j--, m++)
        {
            results[m] = weights[j];
        }
        return results;
    }
}
