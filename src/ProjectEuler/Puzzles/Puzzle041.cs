// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=41</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle041 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the largest n-digit pandigital prime that exists?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int current = 0;

            foreach (int value in Maths.Primes(999999999))
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
