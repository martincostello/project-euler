// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=34</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle034 : Puzzle
    {
        /// <summary>
        /// An array containing the factorials of single digit numbers. This field is read-only.
        /// </summary>
        private static readonly int[] Factorials = new[]
        {
            Maths.Factorial(0),
            Maths.Factorial(1),
            Maths.Factorial(2),
            Maths.Factorial(3),
            Maths.Factorial(4),
            Maths.Factorial(5),
            Maths.Factorial(6),
            Maths.Factorial(7),
            Maths.Factorial(8),
            Maths.Factorial(9),
        };

        /// <inheritdoc />
        public override string Question => "Find the sum of all numbers which are equal to the sum of the factorial of their digits.";

        /// <summary>
        /// Returns whether a specified number is a curious number.
        /// </summary>
        /// <param name="value">The value to test for curiosity,</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is a curious number; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsCurious(int value)
        {
            var digits = value
                .ToString(CultureInfo.InvariantCulture)
                .ToCharArray()
                .Select((p) => p - '0')
                .ToArray();

            long factorialSum = digits
                .Select((p) => Factorials[p])
                .Sum();

            return factorialSum == value;
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int upperBound = 0;

            for (int digits = 2; ; digits++)
            {
                int digitSum = Factorials[9] * digits;

                if (digitSum.ToString(CultureInfo.InvariantCulture).Length <= digits)
                {
                    upperBound = digitSum;
                    break;
                }
            }

            int sum = 0;

            for (int n = 3; n < upperBound; n++)
            {
                if (IsCurious(n))
                {
                    sum += n;
                }
            }

            Answer = sum;

            return 0;
        }
    }
}
