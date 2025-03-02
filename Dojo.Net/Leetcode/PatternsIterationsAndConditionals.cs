using System;

namespace Dojo.Net.Leetcode;

public class PatternsIterationsAndConditionals
{
    public void NDimensionalForestBruteForce(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
    
    public void NDimensionalForestCacheArray(int n)
    {
        char[] line = new char[n];
        for (int j = 0; j < n; j++)
        {
            line[j] = '*';
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(line);
        }
    }

    public void NBy2DimensionalForest(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public void NTriangle(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                int compute = j + 1; // NxN compute steps
                Console.Write(compute);
            }
            Console.WriteLine();
        }
    }
    
    public void NTriangleCached(int n)
    {
        int[] cache = new int[n];
        for (int i = 0; i < n; i++)
        {
            int compute = i + 1; // Compute moved to outer loop
            cache[i] = compute; // Cache results and reuse them
            for (int j = 0; j <= i; j++)
            {
                Console.Write(cache[j]);
            }
            Console.WriteLine();
        }
    }
    
    public void NTriangleRows(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(i + 1);
            }
            Console.WriteLine();
        }
    }
}