// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

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

        var foundDigits = new List<int>(digitsToFind.Length);

        int nextToFind = 0;

        Span<char> digits = stackalloc char[16];

        for (int i = 1; i < limit && nextToFind < digitsToFind.Length; i++)
        {
            i.TryFormat(digits, out int digitCount, default, CultureInfo.InvariantCulture);

            for (int j = 0; j < digitCount && nextToFind < digitsToFind.Length; j++)
            {
                currentIndex++;

                if (currentIndex == digitsToFind[nextToFind])
                {
                    foundDigits.Add(digits[j] - '0');
                    nextToFind++;
                }
            }
        }

        Answer = foundDigits.Aggregate((x, y) => x * y);

        return 0;
    }
}
