// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=35</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle035 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "How many circular primes are there below the specified value?";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <summary>
    /// Returns all the rotations of the digits of the specified value.
    /// </summary>
    /// <param name="value">The value to get the rotations for.</param>
    /// <returns>
    /// An <see cref="IList{T}"/> containing the rotations of <paramref name="value"/>.
    /// </returns>
    internal static IList<long> GetRotations(int value)
    {
        if (value < 12)
        {
            // The only rotation for values less than 12 is the value itself
            return [value];
        }

        // Find the number of digits and the magnitude of the most significant digit
        int digitCount = 1;
        long magnitude = 1;

        for (int remaining = value / 10; remaining > 0; remaining /= 10)
        {
            digitCount++;
            magnitude *= 10;
        }

        var result = new List<long>(digitCount)
        {
            value,
        };

        long rotation = value;

        for (int i = 0; i < digitCount - 1; i++)
        {
            // Move the most significant digit to the end of the value
            (long first, long rest) = Math.DivRem(rotation, magnitude);
            rotation = (rest * 10) + first;

            result.Add(rotation);
        }

        return result;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int maximum) || maximum < 2)
        {
            Console.WriteLine("The specified number is invalid.");
            return -1;
        }

        Answer = Maths.Primes(maximum)
            .AsParallel()
            .Select(GetRotations)
            .Where((p) => p.All(Maths.IsPrime))
            .Count();

        return 0;
    }
}
