﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
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
            int[] digits = Maths.Digits(value);

            int sum = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                sum += Factorials[digits[i]];
            }

            return sum == value;
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int sum = 0;
            int upperBound = 0;

            for (int digitCount = 2; ; digitCount++)
            {
                sum = Factorials[9] * digitCount;
                int[] digitsOfSum = Maths.Digits(sum);

                if (digitsOfSum.Length <= digitCount)
                {
                    upperBound = sum;
                    break;
                }
            }

            sum = 0;

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
