using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Dojo.Net.Leetcode;

public class ItemsInContainers
{
    public int[] GetItemsInClosedContainers(string compartments, int[] startIndices, int[] endIndices)
    {
        List<int> counts = [];
        for (int i = 0; i < startIndices.Length; i++)
        {
            int startIndex = startIndices[i] - 1;
            int endIndex = endIndices[i];
            
            int countOfItems = 0;
            List<int> walls = [];
            
            for (int k = startIndex; k < endIndex; k++)
            {
                if(compartments[k] == '|')
                {
                    walls.Add(k);
                }
            }
            
            if (walls.Count < 2) continue;

            for (int j = 1; j < walls.Count; j++)
            {
                countOfItems += walls[j] - (walls[j - 1] + 1);
            }

            counts.Add(countOfItems);
        }

        return [.. counts];
    }
}
