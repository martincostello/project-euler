// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=38</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle038 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?";

        /// <summary>
        /// Returns a <see cref="string"/> containing the pandigital of a value for a the integer sequence up to the specified number.
        /// </summary>
        /// <param name="value">The value to create the pandigital for.</param>
        /// <param name="n">The maximum value of the integer series.</param>
        /// <returns>
        /// A <see cref="string"/> containing the pandigital for <paramref name="value"/> and <paramref name="n"/>.
        /// </returns>
        internal static string Pandigital(int value, int n)
        {
            var builder = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                int product = value * i;
                builder.AppendFormat(CultureInfo.InvariantCulture, "{0}", product);
            }

            return builder.ToString();
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            // The maximum value will be approximately half of
            // the largest 5 digit number possible as n + 2n
            // would be a minimum of 10 digits in length.
            const int TargetLength = 9;
            const int Limit = 99999 / 2;

            var pandigitals = new List<string>();

            for (int value = 1; value < Limit; value++)
            {
                for (int n = 2; ; n++)
                {
                    string pandigital = Pandigital(value, n);

                    if (pandigital.Length == TargetLength)
                    {
                        if (Maths.IsPandigital(long.Parse(pandigital, NumberStyles.Integer, CultureInfo.InvariantCulture)))
                        {
                            pandigitals.Add(pandigital);
                        }
                    }
                    else if (pandigital.Length > 9)
                    {
                        break;
                    }
                }
            }

            pandigitals.Sort();
            Answer = int.Parse(pandigitals.Last(), NumberStyles.Integer, CultureInfo.InvariantCulture);

            return 0;
        }
    }
}
