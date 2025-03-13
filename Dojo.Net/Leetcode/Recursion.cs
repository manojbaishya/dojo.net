using System;

namespace Dojo.Net.Leetcode;

public class Recursion
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
}
