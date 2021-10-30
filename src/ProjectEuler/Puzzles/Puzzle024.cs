// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=24</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle024 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "What is the millionth lexicographic permutation of the digits 0-9?";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        var collection = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var nextDigits = new List<int>(collection);
        var usedDigits = new List<int>(collection.Length);

        int targetLength = collection.Length;
        int remaining = 1000000 - 1;

        for (int i = 1; i < targetLength; i++)
        {
            int rangeSize = Maths.Factorial(targetLength - i);

            int nextDigitIndex = remaining / rangeSize;
            remaining %= rangeSize;

            usedDigits.Add(nextDigits[nextDigitIndex]);
            nextDigits.RemoveAt(nextDigitIndex);

            if (remaining == 0)
            {
                usedDigits.AddRange(nextDigits);
                break;
            }
        }

        Answer = Maths.FromDigits(usedDigits);

        return 0;
    }
}
