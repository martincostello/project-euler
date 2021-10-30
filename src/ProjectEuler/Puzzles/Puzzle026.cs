// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=26</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle026 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        int answer = 0;
        int maximumLength = 0;

        for (int i = 1000; i > 1; i--)
        {
            if (maximumLength >= i)
            {
                break;
            }

            int[] remainders = new int[i];

            int dividend = 1;
            int position = 0;

            while (remainders[dividend] == 0 && dividend != 0)
            {
                remainders[dividend] = position;

                dividend *= 10;
                dividend %= i;

                position++;
            }

            int recurringCycleLength = position - remainders[dividend];

            if (recurringCycleLength > maximumLength)
            {
                maximumLength = recurringCycleLength;
                answer = i;
            }
        }

        Answer = answer;

        return 0;
    }
}
