﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        internal static IList<long> GetRotations(int value)
        {
            int[] digits = Maths.Digits(value);

            var result = new List<long>()
            {
                value,
            };

            for (int i = 0; i < digits.Length - 1; i++)
            {
                var rotationDigits = new int[digits.Length];
                int index = 0;

                for (int j = i + 1; j < digits.Length; j++)
                {
                    rotationDigits[index++] = digits[j];
                }

                for (int j = 0; j < i + 1; j++)
                {
                    rotationDigits[index++] = digits[j];
                }

                double rotation = 0;

                for (int j = 0; j < rotationDigits.Length - 1; j++)
                {
                    rotation += rotationDigits[j] * Math.Pow(10, rotationDigits.Length - j - 1);
                }

                rotation += rotationDigits[rotationDigits.Length - 1];

                result.Add((long)rotation);
            }

            return result;
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int maximum;

            if (!TryParseInt32(args[0], out maximum) || maximum < 2)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            Answer = ParallelEnumerable.Range(2, maximum - 2)
                .Where((p) => Maths.IsPrime(p))
                .Select((p) => GetRotations(p))
                .Where((p) => p.All((r) => Maths.IsPrime(r)))
                .Count();

            return 0;
        }
    }
}
