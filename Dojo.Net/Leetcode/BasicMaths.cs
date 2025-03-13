using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Net.Leetcode;

public class BasicMaths
{
    public int EvenlyDivides(int n) 
    {
        int num = n;
        int count = 0;
        while (num > 0)
        {
            int lastDigit = num % 10;
            if (lastDigit != 0 && n % lastDigit == 0)
            {
                count++;
            }
            num /= 10;
        }
        return count;
    }

    public int ReverseInteger(int x) 
    {
        int reverseNumber = 0;
        int num = x;
        int lastDigit;
        try
        {
            while(num != 0)
            {
                lastDigit = num % 10;
                reverseNumber = checked(reverseNumber * 10 + lastDigit);
                num /= 10;
            }
        }
        catch(OverflowException)
        {
            return 0;
        }
        
        return reverseNumber;
    }

    public bool IsPalindrome(int x) => x >= 0 && ReverseInteger(x) == x;

    public bool IsArmstrongNumber(int num)
    {
        int copy = num;
        int sum = 0;
        while (copy != 0)
        {
            int lastDigit = copy % 10;
            sum += lastDigit * lastDigit * lastDigit;
            copy /= 10;
        }
        
        return sum == num;
    }

    public List<int> GetAllDivisorsDesc(int N)
    {
        List<int> divisors = [];
        var upperBound = Math.Sqrt(N);
        for (int i = 1; i <= upperBound; i++)
        {
            if (N % i == 0)
            {
                divisors.Add(i);
                int complement = N / i;
                if (complement != i) divisors.Add(complement);
            }
        }

        divisors.Sort((x, y) => y.CompareTo(x));
        return divisors;
    }

    public bool IsPrime(int N)
    {
        var factors = GetAllDivisorsDesc(N);
        if (factors.Count == 2 && factors.Contains(1) && factors.Contains(N)) return true;
        else return false;
    }

    public int HighestCommonFactor(int M, int N)
    {
        var factorsM = GetAllDivisorsDesc(M);
        var factorsN = GetAllDivisorsDesc(N);

        int[] union = [.. factorsM.Intersect(factorsN)];
        Array.Sort(union, (x, y) => y.CompareTo(x));

        return union[0];
    }

    public int HighestCommonFactorEuclidean(int M, int N)
    {
        while(M > 0 && N > 0)
        {
            if (M > N) M %= N;
            else N %= M;
        }

        if (M == 0) return N;
        else return M;
    }

    public int LeastCommonMultiple(int M, int N)
    {
        int HCF = HighestCommonFactorEuclidean(M, N);
        int LCM = (M * N) / HCF;
        return LCM;
    }
}
