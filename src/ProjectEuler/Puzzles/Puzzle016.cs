// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=16</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle016 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the sum of the digits of the number 2 raised to the power of the specified number?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int power;

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out power) ||
                power < 0)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            string digits = string.Empty;

            if (power > 0)
            {
                digits = "2";

                for (int i = 2; i <= power; i++)
                {
                    digits = Maths.Add(digits, digits);
                }
            }

            Answer = digits
                .Select((p) => p - '0')
                .DefaultIfEmpty(1)
                .Sum();

            return 0;
        }
    }
}
