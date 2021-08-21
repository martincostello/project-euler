// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=1</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle001 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "What is the sum of all the multiples of 3 or 5 below the given value?";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int max) || max < 1)
        {
            Console.WriteLine("The specified maximum value is invalid.");
            return -1;
        }

        int sum = 0;

        for (int i = 1; i < max; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }

        Answer = sum;

        return 0;
    }
}
