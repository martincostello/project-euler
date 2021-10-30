// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=14</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle014 : Puzzle
{
    /// <summary>
    /// The cache of Collatz sequence lengths from a specified number. This field is read-only.
    /// </summary>
    private static readonly IDictionary<long, int> _cache = new Dictionary<long, int>(1000000);

    /// <inheritdoc />
    public override string Question => "Which starting number, under one million, produces the longest chain?";

    /// <summary>
    /// Gets the length of the Collatz sequence that starts at the specified value.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <returns>
    /// Returns the length of the Collatz sequence starting at <paramref name="start"/>.
    /// </returns>
    internal static int GetCollatzSequenceLength(long start)
    {
        if (!_cache.TryGetValue(start, out int length))
        {
            if (start > 0)
            {
                long current = start;

                bool cacheHit = false;

                while (current != 1 && !cacheHit)
                {
                    if (_cache.TryGetValue(current, out int remainingLength))
                    {
                        length += remainingLength;
                        cacheHit = true;
                        break;
                    }

                    length++;

                    if (current % 2 == 0)
                    {
                        current /= 2;
                    }
                    else
                    {
                        current = (3 * current) + 1;
                    }
                }

                if (!cacheHit)
                {
                    length++;
                }
            }

            _cache[start] = length;
        }

        return length;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        int longestChain = 0;
        int longestStartValue = 0;

        for (int n = 1; n < 1000000; n++)
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
