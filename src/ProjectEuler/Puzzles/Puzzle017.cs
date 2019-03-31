// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=17</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle017 : Puzzle
    {
        /// <summary>
        /// A dictionary containing the English words for numbers keyed by their value. This field is read-only.
        /// </summary>
        private static readonly Dictionary<int, string> NumberWords = new Dictionary<int, string>()
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
        };

        /// <inheritdoc />
        public override string Question => "If all the numbers from 1 to the specified value inclusive were written out in words, how many letters would be used?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <summary>
        /// Returns the British English representation of the specified number.
        /// </summary>
        /// <param name="value">The number to return the British English representation of.</param>
        /// <returns>
        /// he British English representation of <paramref name="value"/>.
        /// </returns>
        internal static string ToEnglish(int value)
        {
            if (NumberWords.TryGetValue(value, out string result))
            {
                return result;
            }

            // 2345 -> 2 and 2000
            int thousands = value / 1000;
            int justTheThousands = thousands * 1000;

            // 2345 -> 3 and 300
            int hundreds = (value - justTheThousands) / 100;
            int justTheHundreds = hundreds * 100;

            // 2345 -> 4, 40 and 5
            int justTheTens = value - justTheThousands - justTheHundreds;
            int tens = justTheTens / 10;
            int ones = justTheTens % 10;

            StringBuilder builder = new StringBuilder();

            if (thousands > 0)
            {
                builder
                    .Append(NumberWords[thousands])
                    .Append(" thousand");
            }

            if (hundreds > 0)
            {
                if (builder.Length > 0)
                {
                    builder.Append(' ');
                }

                builder
                    .Append(NumberWords[hundreds])
                    .Append(" hundred");
            }

            if (tens > 0)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" and ");
                }

                int tenValue = tens * 10;

                // Is this a special "ten" like "fifteen"?
                if (NumberWords.TryGetValue(tenValue + ones, out result))
                {
                    builder.Append(result);

                    // Clear the ones as we do not need to print them
                    ones = 0;
                }
                else
                {
                    builder.Append(NumberWords[tenValue]);
                }
            }

            if (ones > 0)
            {
                // Every value less than twenty-one has a special case,
                // so we always need to add something before the ones.
                if (tens < 1)
                {
                    // Values like "three hundred and one"
                    builder.Append(" and ");
                }
                else
                {
                    // Values like "eighty-six"
                    builder.Append('-');
                }

                builder.Append(NumberWords[ones]);
            }

            return builder.ToString();
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int max) || max < 1)
            {
                Console.WriteLine("The specified number is invalid.");
                return -1;
            }

            int sum = 0;

            for (int i = 1; i <= max; i++)
            {
                sum += ToEnglish(i)
                    .Replace(" ", string.Empty, StringComparison.Ordinal)
                    .Replace("-", string.Empty, StringComparison.Ordinal)
                    .Length;
            }

            Answer = sum;

            return 0;
        }
    }
}
