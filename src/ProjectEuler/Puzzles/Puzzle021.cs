﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Collections.Concurrent;

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=21</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle021 : Puzzle
{
    /// <summary>
    /// A cache of the result of invocations of <see cref="D(long)"/>. This field is read-only.
    /// </summary>
    private static readonly ConcurrentDictionary<long, long> _cache = new();

    /// <inheritdoc />
    public override string Question => "Evaluate the sum of all the amicable numbers under 10,000.";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        var amicableNumbers = new HashSet<long>();

        for (int a = 1; a < 10_000; a++)
        {
            long b = D(a);

            if (b != a && D(b) == a)
            {
                _ = amicableNumbers.Add(a);
                _ = amicableNumbers.Add(b);
            }
        }

        Answer = amicableNumbers.Sum();

        return 0;
    }

    /// <summary>
    /// Finds the sum of the proper divisors of the specified value.
    /// </summary>
    /// <param name="value">The value to find the proper divisor sum for.</param>
    /// <returns>
    /// The sum of the proper divisors of <paramref name="value"/>.
    /// </returns>
    private static long D(long value)
        => _cache.GetOrAdd(value, (p) => Maths.GetProperDivisors(p).Sum());
}
