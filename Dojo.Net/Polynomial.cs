using System;
using System.Linq;
using System.Numerics;

namespace Dojo.Net;

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
        if (degreeBound == 1) return [.. coefficients.Select(x => new Complex(x, 0))];
        var wn = Complex.Exp(2 * Math.PI * Complex.ImaginaryOne / degreeBound);
        var w = new Complex(1, 0);

        Complex[] fftEven = ComputeFft([.. coefficients.Where((_, i) => i % 2 == 0)], degreeBound / 2);
        Complex[] fftOdd = ComputeFft([.. coefficients.Where((_, i) => i % 2 == 1)], degreeBound / 2);

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