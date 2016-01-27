// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=10</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle010 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the sum of all the primes below the specified value.";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int max;

            if (!TryParseInt32(args[0], out max) || max < 2)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            long sum = ParallelEnumerable.Range(3, max - 3)
                .Where((p) => p % 2 != 0)
                .Where((p) => Maths.IsPrime(p))
                .Select((p) => (long)p)
                .Sum();

            Answer = sum + 2;

            return 0;
        }
    }
}
