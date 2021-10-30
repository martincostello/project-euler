// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=92</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle092 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "How many starting numbers below ten million will arrive at 89 from square digit addition?";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        const int Limit = 10_000_000;
        const int Target = 89;

        int count = 0;

        for (int i = 1; i < Limit; i++)
        {
            int value = i;

            while (value != 1 && value != Target)
            {
                value = Maths.Digits(value).Aggregate((x, y) => (x * x) + y);
            }

            if (value == Target)
            {
                count++;
            }
        }

        Answer = count;

        return 0;
    }
}
