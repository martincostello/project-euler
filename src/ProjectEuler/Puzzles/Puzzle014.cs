// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=14</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle014 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Which starting number, under one million, produces the longest chain?";

        /// <summary>
        /// Gets the Collatz sequence that starts at the specified value.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that returns the Collatz sequence starting at <paramref name="start"/>.
        /// </returns>
        internal static IEnumerable<long> GetCollatzSequence(long start)
        {
            if (start > 0)
            {
                long current = start;

                while (current != 1)
                {
                    yield return current;

                    if (current % 2 == 0)
                    {
                        current /= 2;
                    }
                    else
                    {
                        current = (3 * current) + 1;
                    }
                }

                yield return current;
            }
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int longestChain = 0;
            int longestChainSeed = 0;

            for (int i = 1; i < 1000000; i++)
            {
                int chainLength = GetCollatzSequence(i).Count();

                if (chainLength > longestChain)
                {
                    longestChain = chainLength;
                    longestChainSeed = i;
                }
            }

            Answer = longestChainSeed;

            return 0;
        }
    }
}
