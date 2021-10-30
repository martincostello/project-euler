﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=29</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle029 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "How many distinct terms are in the sequence generated by a^b for 2<=a<=n and 2<=b<=n?";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <summary>
    /// Returns the sequence of unique number generated for all combinations of the
    /// integers from 2 to the specified maximum number, inclusive, where a^b.
    /// </summary>
    /// <param name="maximum">The maximum value of a and b.</param>
    /// <returns>
    /// An <see cref="ICollection{T}"/> containing the unique values generated by the sequence.
    /// </returns>
    internal static ICollection<double> GeneratePowerSequence(int maximum)
    {
        var sequence = new HashSet<double>(maximum * maximum);

        for (int a = 2; a <= maximum; a++)
        {
            for (int b = 2; b <= maximum; b++)
            {
                sequence.Add(Math.Pow(a, b));
            }
        }

        return sequence;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int maximum))
        {
            Console.WriteLine("The specified number is invalid.");
            return -1;
        }

        Answer = GeneratePowerSequence(maximum).Count;

        return 0;
    }
}
