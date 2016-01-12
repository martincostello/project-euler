// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Globalization;
    using System.Linq;

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

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out number) ||
                number < 0)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            string factorial = string.Empty;

            if (number > 0)
            {
                factorial = number.ToString(CultureInfo.InvariantCulture);

                // For n -> 0
                for (int n = number; n > 0; n--)
                {
                    string current = factorial;

                    // Add n to the result n-1 times
                    for (int j = 1; j < n - 1; j++)
                    {
                        factorial = Maths.Add(factorial, current);
                    }
                }
            }

            Answer = factorial
                .Select((p) => p - '0')
                .DefaultIfEmpty(1)
                .Sum();

            return 0;
        }
    }
}
