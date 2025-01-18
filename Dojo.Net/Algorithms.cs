using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Dojo.Net;

public class CartItem
{
    public double Price;
}

public class RuntimeAnalysis
{
    public static bool HasDuplicates<T>(IList<T> list) where T : IEquatable<T>
    {
        int size = list.Count;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (i != j && list[i].Equals(list[j])) return true;
            }
        }
        return false;
    }

    public static bool HasDuplicatesWithSorting<T>(IList<T> list) where T : IEquatable<T>
    {
        int size = list.Count;
        IList<T> sortedList = [.. list.OrderBy(val => val)];
        for (int i = 0; i < sortedList.Count - 1; i++)
        {
            if (sortedList[i].Equals(sortedList[i + 1])) return true;
        }
        return false;
    }

    public static bool HasDuplicatesWithSets<T>(IList<T> list) where T : IEquatable<T>
    {
        HashSet<T> set = [];
        foreach (T item in list)
        {
            if (set.Contains(item)) return true;
            set.Add(item);
        }

        return false;
    }

    public static bool HasDuplicatesWithSetLength<T>(IList<T> list) where T : IEquatable<T>
    {
        HashSet<T> set = [.. list];
        return set.Count != list.Count;
    }
}

public class Polynomial(params double[] coefficients)
{
    public double[] Coefficients { get; } = coefficients;
    public Complex[]? Fft {get; private set; }
    public int DegreeBound => Coefficients.Length;

    public Complex[] ComputeFft() {
        Fft = ComputeFft(Coefficients, DegreeBound);
        return Fft;
    }

    private static Complex[] ComputeFft(double[] coefficients, int degreeBound) {
        if (degreeBound == 1) return coefficients.Select(x => new Complex(x, 0)).ToArray();
        var wn = Complex.Exp(2 * Math.PI * Complex.ImaginaryOne / degreeBound);
        var w = new Complex(1, 0);

        Complex[] fftEven = ComputeFft(coefficients.Where((_, i) => i % 2 == 0).ToArray(), degreeBound / 2);
        Complex[] fftOdd = ComputeFft(coefficients.Where((_, i) => i % 2 == 1).ToArray(), degreeBound / 2);

        Complex[] fft = new Complex[degreeBound];
        for (int i = 0; i < degreeBound / 2; i++) {
            fft[i] = fftEven[i] + w * fftOdd[i];
            fft[i + degreeBound / 2] = fftEven[i] - w * fftOdd[i];
            w *= wn;
        }

        return fft;
    }

    public override string ToString() {
        string polynomial = "";
        for (int i = 0; i < Coefficients.Length; i++) {
            if (i == 0) polynomial += $"{Coefficients[i]}";
            else if (i == 1) polynomial += $" + {Coefficients[i]}x";
            else polynomial += $" + {Coefficients[i]}x^{i}";
        }
        return polynomial;
    }
}