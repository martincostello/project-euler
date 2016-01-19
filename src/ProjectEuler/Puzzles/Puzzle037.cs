// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=37</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle037 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the sum of the only eleven primes that are both truncatable from left to right and right to left.";

        /// <summary>
        /// Returns whether continuous truncation of the specified value (both to
        /// the left and to the right) results in values that are all prime numbers.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>
        /// <see langword="true"/> if all the truncated values are prime; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool AllTruncatedValuesArePrime(int value)
        {
            if (!Maths.IsPrime(value) || value <= 7)
            {
                return false;
            }

            return
                AllTruncatedValuesArePrime(value, removeLeft: true) &&
                AllTruncatedValuesArePrime(value, removeLeft: false);
        }

        /// <summary>
        /// Truncates the specified number by removing a digit.
        /// </summary>
        /// <param name="value">The value to truncate.</param>
        /// <param name="removeLeft">Whether to remove the left-most digit.</param>
        /// <returns>
        /// The truncated representation of <paramref name="value"/> after either the left or right digit is removed.
        /// </returns>
        internal static long Truncate(long value, bool removeLeft)
        {
            var digits = new List<int>(Maths.Digits(value));

            digits.RemoveAt(removeLeft ? 0 : digits.Count - 1);

            return Maths.FromDigits(digits);
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            var truncatablePrimes = new List<int>();

            // 11 is the first two digit prime. It is also the number of truncatable primes.
            for (int n = 11; truncatablePrimes.Count < 11; n++)
            {
                if (AllTruncatedValuesArePrime(n))
                {
                    truncatablePrimes.Add(n);
                }
            }

            Answer = truncatablePrimes.Sum();

            return 0;
        }

        /// <summary>
        /// Returns whether continuous truncation of the specified value (both to
        /// the left and to the right) results in values that are all prime numbers.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="removeLeft">Whether to remove the left-most digit.</param>
        /// <returns>
        /// <see langword="true"/> if all the truncated values are prime; otherwise <see langword="false"/>.
        /// </returns>
        private static bool AllTruncatedValuesArePrime(int value, bool removeLeft)
        {
            long truncated = value;

            while (truncated > 9)
            {
                truncated = Truncate(truncated, removeLeft);

                if (!Maths.IsPrime(truncated))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
