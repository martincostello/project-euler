// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=52</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle052 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "What is the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits?";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        for (int i = 1; i < int.MaxValue; i++)
        {
            (int digitCount, int digitSet) = GetDigitSignature(i);

            bool hasSameDigits = true;

            for (int multiplier = 2; multiplier <= 6 && hasSameDigits; multiplier++)
            {
                (int multipleDigitCount, int multipleDigitSet) = GetDigitSignature(i * multiplier);

                hasSameDigits =
                    multipleDigitCount == digitCount &&
                    (multipleDigitSet & ~digitSet) == 0;
            }

            if (hasSameDigits)
            {
                Answer = i;
                break;
            }
        }

        return 0;
    }

    /// <summary>
    /// Gets the number of digits in the specified value and the set of distinct digits it contains.
    /// </summary>
    /// <param name="value">The value to get the digit signature for.</param>
    /// <returns>
    /// The number of digits in <paramref name="value"/> and a bit mask of the digits it contains.
    /// </returns>
    private static (int Count, int Set) GetDigitSignature(int value)
    {
        int count = 0;
        int set = 0;

        for (int remaining = value; remaining > 0; remaining /= 10)
        {
            count++;
            set |= 1 << (remaining % 10);
        }

        return (count, set);
    }
}
