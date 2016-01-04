// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=5</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle005 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to the specified value?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int max;

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out max) ||
                max < 2)
            {
                Console.Error.WriteLine("The specified maximum number is invalid.");
                return -1;
            }

            var divisors = Enumerable.Range(1, max).ToList();

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (divisors.All((p) => i % p == 0))
                {
                    Answer = i;
                    break;
                }
            }

            return 0;
        }
    }
}
