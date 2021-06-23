// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=25</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle025 : Puzzle
    {
        /// <summary>
        /// The <see cref="BigInteger"/> that is the first number with 1,000 digits. This field is read-only.
        /// </summary>
        private static readonly BigInteger Limit = BigInteger.Parse("1" + new string('0', 999), CultureInfo.InvariantCulture);

        /// <inheritdoc />
        public override string Question => "What is the number of the first term in the Fibonacci sequence to contain 1,000 digits?";

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> of <see cref="BigInteger"/> that enumerates the Fibonacci sequence.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="BigInteger"/> that enumerates the Fibonacci sequence.
        /// </returns>
        internal static IEnumerable<BigInteger> Fibonacci()
        {
            var x = BigInteger.One;
            var y = BigInteger.One;

            yield return x;
            yield return y;

            while (true)
            {
                BigInteger next = x + y;

                yield return next;

                x = y;
                y = next;
            }
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int index = 0;

            foreach (BigInteger value in Fibonacci())
            {
                index++;

                if (value >= Limit)
                {
                    Answer = index;
                    break;
                }
            }

            return 0;
        }
    }
}
