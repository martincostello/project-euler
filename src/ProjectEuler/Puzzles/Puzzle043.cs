// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=43</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle043 : Puzzle
{
    /// <summary>
    /// An array containing the indexes and divisors to search the digit
    /// groups of in the 0-9 pandigital numbers. This field is read-only.
    /// </summary>
    private static readonly (int Index, int Divisor)[] _ranges =
    {
        (3 - 1, 3),
        (4 - 1, 5),
        (5 - 1, 7),
        (6 - 1, 11),
        (7 - 1, 13),
        (8 - 1, 17),
    };

    /// <inheritdoc />
    public override string Question => "Find the sum of all 0 to 9 pandigital numbers where each ascending group of three digits from digit 2 is divisible by the ascending prime numbers.";

    /// <summary>
    /// Returns whether the specified number, in the form of its digits, has the desired property.
    /// </summary>
    /// <param name="digits">Whether the specified value has the desired property.</param>
    /// <returns>
    /// <see langword="true"/> if the value from <paramref name="digits"/> has the desired property; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool HasProperty(IList<int> digits)
    {
        // Fast path:
        // 1) Exclude all values that start with zero
        // 2) Exclude all values where d4 is not even as d2d3d4 must be divisible by 2
        if (digits[0] == 0 || digits[3] % 2 != 0)
        {
            return false;
        }

        bool hasProperty = true;

        foreach ((int start, int divisor) in _ranges)
        {
            int end = start + 3;

            IList<int> subdigits = digits
                .Take(start..end)
                .ToList();

            long subvalue = Maths.FromDigits(subdigits);

            if (subvalue % divisor != 0)
            {
                hasProperty = false;
                break;
            }
        }

        return hasProperty;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
#pragma warning disable CA1861
        var pandigitals = Maths.Permutations(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        var pandigitalsWithProperty = new List<long>();
#pragma warning restore CA1861

        foreach (var pandigital in pandigitals)
        {
            IList<int> digits = pandigital.ToArray();

            if (HasProperty(digits))
            {
                long value = Maths.FromDigits(digits);
                pandigitalsWithProperty.Add(value);
            }
        }

        long sum = 0;
        int count = pandigitalsWithProperty.Count;

        for (int i = 0; i < count; i++)
        {
            sum += pandigitalsWithProperty[i];
        }

        Answer = sum;

        return 0;
    }
}
