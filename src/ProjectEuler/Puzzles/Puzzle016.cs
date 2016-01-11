// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
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

            IList<char> digits = new List<char>();

            if (power > 0)
            {
                digits.Add('2');

                for (int i = 2; i <= power; i++)
                {
                    digits = Double(digits);
                }
            }

            Answer = digits
                .Select((p) => p - '0')
                .DefaultIfEmpty(1)
                .Sum();

            return 0;
        }

        /// <summary>
        /// Doubles the specified numer represented by its character digits.
        /// </summary>
        /// <param name="digits">The digits of the number as characters.</param>
        /// <returns>
        /// An <see cref="IList{T}"/> containing characters of the double of the specified number.
        /// </returns>
        private static IList<char> Double(IList<char> digits)
        {
            List<char> result = new List<char>();

            int carry = 0;

            // Work through the digits from the ones column upwards
            for (int i = digits.Count - 1; i > -1; i--)
            {
                // Get the number for this digit from its character
                int number = digits[i] - '0';

                // Double the number and include any value that needs carrying over
                int sum = number + number + carry;

                // Carry over the tens column
                carry = sum / 10;

                // Adjust the sum to just the ones if required and add to
                // the result as a new column on the left of the digits.
                if (sum > 9)
                {
                    sum -= 10;
                }

                result.Insert(0, (char)(sum + '0'));
            }

            // Add the digit for any left over carry value
            if (carry != 0)
            {
                result.Insert(0, (char)(carry + '0'));
            }

            return result;
        }
    }
}
