// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=35</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle035 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "How many circular primes are there below the specified value?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <summary>
        /// Returns all the rotations of the digits of the specified value.
        /// </summary>
        /// <param name="value">The value to get the rotations for.</param>
        /// <returns>
        /// An <see cref="IList{T}"/> containing the rotations of <paramref name="value"/>.
        /// </returns>
        internal static IList<int> GetRotations(int value)
        {
            var chars = value.ToString(CultureInfo.InvariantCulture).ToCharArray();

            var result = new List<int>()
            {
                value,
            };

            for (int i = 0; i < chars.Length - 1; i++)
            {
                var rotation = new char[chars.Length];
                int index = 0;

                for (int j = i + 1; j < chars.Length; j++)
                {
                    rotation[index++] = chars[j];
                }

                for (int j = 0; j < i + 1; j++)
                {
                    rotation[index++] = chars[j];
                }

                result.Add(int.Parse(new string(rotation), CultureInfo.InvariantCulture));
            }

            return result;
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int maximum;

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out maximum) ||
                maximum < 2)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            var primes = new List<int>();
            var circularPrimes = new List<int>();

            for (int n = 2; n < maximum; n++)
            {
                if (Maths.IsPrime(n))
                {
                    var rotations = GetRotations(n);

                    bool isCircularPrime = true;

                    foreach (int value in rotations)
                    {
                        if (primes.Contains(value))
                        {
                            continue;
                        }

                        if (Maths.IsPrime(value))
                        {
                            primes.Add(value);
                        }
                        else
                        {
                            isCircularPrime = false;
                            break;
                        }
                    }

                    if (isCircularPrime)
                    {
                        circularPrimes.Add(n);
                    }
                }
            }

            Answer = circularPrimes.Count;

            return 0;
        }
    }
}
