// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=36</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle036 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.";

    /// <summary>
    /// Returns whether the specified <see cref="string"/> is palindromic.
    /// </summary>
    /// <param name="value">The value to test for being a palindrome.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> is a palindrome; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsPalindromic(string value) => Helpers.IsPalindromic(value.ToCharArray());

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        int sum = 0;

        for (int i = 1; i < 1_000_000; i++)
        {
            if (IsPalindromic(Convert.ToString(i, 10)) &&
                IsPalindromic(Convert.ToString(i, 2)))
            {
                sum += i;
            }
        }

        Answer = sum;

        return 0;
    }
}
