// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=14</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle014 : Puzzle
{
    /// <summary>
    /// The number of starting values to cache the sequence lengths for.
    /// </summary>
    private const int CacheSize = 1_000_000;

    /// <summary>
    /// A cache of the sequence lengths for starting values below <see cref="CacheSize"/>.
    /// A value of zero indicates the length has not yet been computed. This field is read-only.
    /// </summary>
    private static readonly int[] _cache = new int[CacheSize];

    /// <inheritdoc />
    public override string Question => "Which starting number, under one million, produces the longest chain?";

    /// <summary>
    /// Gets the length of the Collatz sequence for the specified starting value.
    /// </summary>
    /// <param name="start">The starting value.</param>
    /// <returns>
    /// The length of the Collatz sequence for <paramref name="start"/>.
    /// </returns>
    internal static int GetCollatzSequenceLength(long start)
    {
        if (start < 1)
        {
            return 0;
        }

        int[] cache = _cache;

        if (start < cache.Length)
        {
            int cached = cache[start];

            if (cached != 0)
            {
                return cached;
            }
        }

        long current = start;
        int length = 0;

        bool cacheHit = false;

        while (current != 1)
        {
            if (current < cache.Length)
            {
                int remainingLength = cache[current];

                if (remainingLength != 0)
                {
                    length += remainingLength;
                    cacheHit = true;
                    break;
                }
            }

            length++;

            current = (current & 1) == 0 ? current >> 1 : (3 * current) + 1;
        }

        if (!cacheHit)
        {
            length++;
        }

        if (start < cache.Length)
        {
            cache[start] = length;
        }

        return length;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        int longestChain = 0;
        int longestStartValue = 0;

        for (int n = 1; n < 1_000_000; n++)
        {
            int length = GetCollatzSequenceLength(n);

            if (length > longestChain)
            {
                longestChain = length;
                longestStartValue = n;
            }
        }

        Answer = longestStartValue;

        return 0;
    }
}
