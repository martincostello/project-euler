// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=5</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle005 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to the specified value?";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int max) || max < 2)
        {
            Console.WriteLine("The specified maximum number is invalid.");
            return -1;
        }

        // Do not need to bother testing for divisibility by 1, plus the
        // for loop below only tests even numbers so can also exclude 2.
        int[] divisors = [.. Enumerable.Range(3, max - 2)];
        int divisorCount = divisors.Length;

        int step = 2;
        int start = max % 2 == 0 ? max : max - 1;

        // Fast path for large numbers: the answer must be divisible by
        // 3, 5 and 10, so only multiples of 30 need to be considered.
        if (max >= 10)
        {
            step = 30;
            start = (start + step - 1) / step * step;
        }

        for (int n = start; ; n += step)
        {
            bool found = true;

            // Test the largest divisors first as they are the most likely to fail
            for (int i = divisorCount - 1; i >= 0; i--)
            {
                if (n % divisors[i] != 0)
                {
                    found = false;
                    break;
                }
            }

            if (found)
            {
                Answer = n;
                break;
            }
        }

        return 0;
    }
}
