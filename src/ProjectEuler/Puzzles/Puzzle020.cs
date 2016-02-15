// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=20</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle020 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the sum of the digits in the factorial for the specified number (i.e. N!).";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int number;

            if (!TryParseInt32(args[0], out number) || number < 0)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            BigInteger factorial = 1;

            if (number > 0)
            {
                factorial = number;

                // For n -> 0
                for (int n = number - 1; n > 0; n--)
                {
                    factorial = factorial * n;
                }
            }

            Answer = Maths.Digits(factorial)
                .DefaultIfEmpty(1)
                .Sum();

            return 0;
        }
    }
}
