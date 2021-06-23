// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Linq;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=41</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle041 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the largest n-digit pandigital prime that exists?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            // 1..n is divisble by 3 (and hence not prime)
            // if the sum of the digits is divisble by 3.
            // Determine the maximum number of digits for
            // a pandigital that is not divisible by 3.
            int maxDigits = Enumerable.Range(2, 9 - 2)
                .Select((p) => Enumerable.Range(1, p))
                .Where((p) => p.Sum() % 3 != 0)
                .SelectMany((p) => p)
                .Max();

            int upperLimit = (int)Maths.FromDigits(Enumerable.Range(1, maxDigits).Reverse().ToArray());

            int current = 0;

            foreach (int value in Maths.Primes(upperLimit))
            {
                if (value > current && Maths.IsPandigital(value))
                {
                    current = value;
                }
            }

            Answer = current;

            return 0;
        }
    }
}
