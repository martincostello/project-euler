// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=46</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle046 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?";

        /// <summary>
        /// Returns whether the specified value can be written as the sum of a prime number and twice a square.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> can be written as the sum of a prime number
        /// and twice a square; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool CanBeWrittenAsTheSumOfAPrimeAndTwiceASquare(int value)
        {
            double limit = Math.Sqrt(value / 2);

            for (int i = 1; i < limit; i++)
            {
                int candidate = value - (2 * (int)Math.Pow(i, 2));

                if (Maths.IsPrime(candidate))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            for (int i = 35; ; i += 2)
            {
                if (Maths.IsPrime(i))
                {
                    continue;
                }

                if (!CanBeWrittenAsTheSumOfAPrimeAndTwiceASquare(i))
                {
                    Answer = i;
                    break;
                }
            }

            return 0;
        }
    }
}
