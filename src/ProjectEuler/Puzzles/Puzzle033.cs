// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=33</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle033 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "If the product of the four non-trivial curious fractions less than one with two digits in the numerator and denominator is given in its lowest common terms, what is the value of the denominator?";

    /// <summary>
    /// Returns whether the specified fraction is 'curious'.
    /// </summary>
    /// <param name="numerator">The value of the numerator.</param>
    /// <param name="denominator">The value of the denominator.</param>
    /// <returns>
    /// <see langword="true"/> if the fraction is considered 'curious'; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsCuriousFraction(double numerator, double denominator)
    {
        IReadOnlyList<int> numeratorDigits = Maths.Digits((long)numerator);
        IReadOnlyList<int> denominatorDigits = Maths.Digits((long)denominator);

        if (numeratorDigits.Count != 2 || denominatorDigits.Count != 2 || numeratorDigits[1] != denominatorDigits[0])
        {
            return false;
        }

        var originalFraction = numerator / denominator;
        var curiousFraction = (double)numeratorDigits[0] / denominatorDigits[1];

        return originalFraction == curiousFraction;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        var curiousFractions = new List<(double Numerator, double Denominator)>();

        for (double numerator = 10d; numerator < 100d; numerator++)
        {
            for (double denominator = 10d; denominator < 100d; denominator++)
            {
                if (!IsCuriousFraction(numerator, denominator))
                {
                    continue;
                }

                double value = numerator / denominator;

                if (value >= 1.0)
                {
                    continue;
                }

                curiousFractions.Add((numerator, denominator));
            }
        }

        double product = 1;

        foreach (var (numerator, denominator) in curiousFractions)
        {
            product *= numerator / denominator;
        }

        Answer = ToFraction(product).Denominator;

        return 0;
    }

    /// <summary>
    /// Returns the specified value as a fraction.
    /// </summary>
    /// <param name="value">The value to convert to a fraction.</param>
    /// <returns>
    /// A <see cref="Tuple{T1, T2}"/> containing the numerator and denominator of the fraction.
    /// </returns>
    private static (int Numerator, int Denominator) ToFraction(double value)
    {
        double numerator = value;
        double denominator = 1;

        while (numerator <= 1)
        {
            numerator *= 10;
            denominator *= 10;
        }

        return ((int)numerator, (int)denominator);
    }
}
