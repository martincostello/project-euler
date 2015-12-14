// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Globalization;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=3</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle003 : Puzzle
    {
        public override string Question => "What is the largest prime factor of the specified number?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            long max;

            if (!long.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out max) ||
                max < 1)
            {
                Console.Error.WriteLine("The specified maximum value is invalid.");
                return -1;
            }

            for (long i = (long)Math.Sqrt(max); i > 1; i--)
            {
                if (max % i == 0 && Maths.IsPrime(i))
                {
                    Answer = i;
                    break;
                }
            }

            return 0;
        }
    }
}
