// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=47</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle047 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "Find the first N consecutive integers to have N distinct prime factors. What is the first of these numbers?";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int factors) || factors < 2)
        {
            Console.WriteLine("The specified number of factors is invalid.");
            return -1;
        }

        for (int i = 1; ; i++)
        {
            if (Enumerable.Range(i, factors).All((p) => HasPrimeFactors(p, factors)))
            {
                Answer = i;
                break;
            }
        }

        return 0;
    }

    /// <summary>
    /// Returns whether the specified value has the specified
    /// number of factors that are prime numbers.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <param name="count">The number of prime factors to test for.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> has exactly
    /// <paramref name="count"/> prime factors; otherwise <see langword="false"/>.
    /// </returns>
    private static bool HasPrimeFactors(int value, int count)
    {
        using var enumerator = Maths.GetFactorsUnordered(value).GetEnumerator();

        int primes = 0;

        while (enumerator.MoveNext() && primes < count)
        {
            if (Maths.IsPrime(enumerator.Current))
            {
                primes++;
            }
        }

        return primes == count;
    }
}
