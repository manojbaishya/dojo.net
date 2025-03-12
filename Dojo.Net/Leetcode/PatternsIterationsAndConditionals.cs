using System;
using Perfolizer.Mathematics.Cpd;

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

    public void Seeding(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }

    public void NNumberTriangle(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write(j + 1);
            }
            Console.WriteLine();
        }
    }

    public void NStarTriangle(int n)
    {
        const int a0 = 1;
        const int del = 2;
        int l = a0 + (n - 1) * del;
        for (int i = 0; i < n; i++)
        {
            int c = a0 + i * del;
            int sp = (l - c) / 2;
            for (int j = 0; j < l; j++)
            {
                if (sp <= j && j < l - sp) Console.Write('*');
                else Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
    
    public void NStarTriangleReversed(int n)
    {
        const int a0 = 1;
        const int del = 2;
        int l = a0 + (n - 1) * del;
        for (int i = 0; i < n; i++)
        {
            int c = a0 + i * del;
            int sp = i * 2;
            for (int j = 0; j < l; j++)
            {
                if (sp <= j && j < l - sp) Console.Write('*');
                else Console.Write(' ');
            }
            Console.WriteLine();
        }
    }

    public void NStarTriangleDouble(int n)
    {
        NStarTriangle(n);
        NStarTriangleReversed(n);
    }
    
    public void NStarTriangleDoubleOneSided(int n)
    {
        NBy2DimensionalForest(n);
        Seeding(n - 1);
    }
    
    public void NTriangleBinary(int n)
    {
        for (int i = 0; i < n; i++)
        {
            int init = i % 2 == 0 ? 1 : 0;
            for (int j = 0; j <= i; j++)
            {
                Console.Write(init);
                init ^= 1;
            }

            Console.WriteLine();
        }
    }
    
    public void McDonalds(int n)
    {
        int l = n * 2;
        for (int i = 0; i < n; i++)
        {
            int num = i + 1;
            for (int j = 0; j < l; j++)
            {
                if (num <= j && j < l - num) Console.Write(' ');
                else if (j < num) Console.Write(j + 1);
                else Console.Write(l - j);
            }
            Console.WriteLine();
        }
    }
    
    public void IncrementalNumbers(int n)
    {
        int marker = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                Console.Write($"{marker} ");
                marker++;
            }
            Console.WriteLine();
        }
    }
    
    public void Diamond(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write('*');
            }

            for (int j = 0; j < 2 * i; j++)
            {
                Console.Write(' ');
            }
            
            for (int j = 0; j < n - i; j++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                Console.Write('*');
            }

            for (int j = 0; j < 2 * n - 2 * (i + 1); j++)
            {
                Console.Write(' ');
            }
            
            for (int j = 0; j < i + 1; j++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }
}