﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=6</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle006 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the difference between the sum of the squares of the specified number of natural numbers and the square of their sum?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int numbers) || numbers < 1)
            {
                Console.WriteLine("The specified number is invalid.");
                return -1;
            }

            var range = Enumerable.Range(1, numbers);

            double sumOfSquares = range
                .Select((p) => Math.Pow(p, 2))
                .Sum();

            double squareOfSum = Math.Pow(range.Sum(), 2);

            Answer = (int)(squareOfSum - sumOfSquares);

            return 0;
        }
    }
}
