using System;
using System.Text.RegularExpressions;

namespace Dojo.Net.Leetcode;

public partial class Recursion
{
    public void PrintStringNTimes(string name, int iterations, int count)
    {
        iterations++;
        Console.WriteLine($"Name: {name}");
        
        if (iterations >= count) return;
        PrintStringNTimes(name, iterations, count);
    }

    public void PrintNTimes(int iterations, int count)
    {
        iterations++;
        Console.WriteLine(iterations.ToString());
        
        if (iterations >= count) return;
        PrintNTimes(iterations, count);
    }

    public void PrintNTimesReverse(int iterations, int count)
    {
        Console.WriteLine(iterations.ToString());
        iterations--;
        
        if (iterations < 1) return;
        PrintNTimesReverse(iterations, count);
    }

    public void PrintNTimesBacktracking(int iterations, int count)
    {
        if (iterations < 1) return;
        PrintNTimesBacktracking(iterations - 1, count);
        Console.WriteLine(iterations.ToString());
    }

    public void PrintNTimesReverseBacktracking(int iterations, int count)
    {
        if (iterations > count) return;
        PrintNTimesReverseBacktracking(iterations + 1, count);
        Console.WriteLine(iterations.ToString());
    }

    public double SumOfCubicSeries(int n) {
        if (n == 1) return 1;
        return Math.Pow(n, 3) + SumOfCubicSeries(n - 1);
    }

    public double SumofCubicSeriesbyFormula(int n) => Math.Pow((n * (n + 1)) / 2, 2);

    public double SumOfNNumbers(int n) {
        if (n == 1) return 1;
        return n + SumOfNNumbers(n - 1);
    }

    public double SumOfNNumbersbyFormula(int n) => (n * (n + 1)) / 2;

    public double Factorial(int n)
    {
        if (n == 1) return 1;
        return n * Factorial(n - 1);
    }

    public int[] ReverseArray(int[] arr)
    {
        Swap(arr, 0, arr.Length - 1);
        return arr;
    }

    private void Swap(int[] arr, int l, int r)
    {
        if (l >= r) return;
        (arr[l], arr[r]) = (arr[r], arr[l]);
        Swap(arr, l + 1, r - 1);
    }

    public int[] ReverseArrayWithSingleIndex(int[] arr)
    {
        Reverse(arr, 0);
        return arr;
    }

    public void Reverse(int[] arr, int i)
    {
        if (i >= arr.Length / 2) return;
        (arr[i], arr[arr.Length - 1 - i]) = (arr[arr.Length - 1 - i], arr[i]);
        Reverse(arr, i + 1);
    }

    public bool IsPalindrome(string inputString)
    {
        char[] str = inputString.ToCharArray();
        ReverseString(str, 0);
        string? outputString = string.Join(null, str);
        if (outputString is not null) return outputString.Equals(inputString, StringComparison.OrdinalIgnoreCase);
        else return false;
    }

    public void ReverseString(char[] str, int i)
    {
        if (i >= str.Length / 2) return;
        (str[i], str[str.Length - 1 - i]) = (str[str.Length - 1 - i], str[i]);
        ReverseString(str, i + 1);
    }

    public bool IsPalindromeChecks(string inputString) => ReverseStringCheck(inputString.ToCharArray(), 0);

    public bool ReverseStringCheck(char[] str, int i)
    {
        if (i >= str.Length / 2) return true;
        if (str[i] != str[str.Length - 1 - i]) return false;
        return ReverseStringCheck(str, i + 1);
    }

    public bool IsPalindromeWithSanitization(string s) 
    {
        Regex alphanumericFilter = AlphanumericFilter();
        string ip = alphanumericFilter.Replace(s, "").ToLower();
        return ReverseStringCheck(ip.ToCharArray(), 0);
    }

    [GeneratedRegex("[^a-zA-Z0-9]")]
    private static partial Regex AlphanumericFilter();

    public int FibonacciRecursive(int N)
    {
        if (N == 0) return 0;
        if (N == 1) return 1;
        return FibonacciRecursive(N - 1) + FibonacciRecursive(N - 2);
    }
}
