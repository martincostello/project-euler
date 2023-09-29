// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

#pragma warning disable SA1010

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=40</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle040 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "Find the value of the following expression with respect to Champernowne's constant: d1 * d10 * d100 * d1000 * d10000 * d100000 * d1000000";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        int[] digitsToFind = [1, 10, 100, 1000, 10000, 100000, 1000000];

        int currentIndex = 0;
        int limit = digitsToFind.Max();

        var foundDigits = new List<int>(limit);

        for (long i = 1; i < limit; i++)
        {
            IReadOnlyList<int> digits = Maths.Digits(i);

            foreach (int digit in digits)
            {
                currentIndex++;

                if (digitsToFind.Contains(currentIndex))
                {
                    foundDigits.Add(digit);
                }
            }
        }

        Answer = foundDigits.Aggregate((x, y) => x * y);

        return 0;
    }
}
