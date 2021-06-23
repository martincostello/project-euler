// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System;

namespace MartinCostello.ProjectEuler.Puzzles
{
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

            double sumOfRange = 0;
            double sumOfSquares = 0;

            for (int i = 0; i < numbers; i++)
            {
                int value = i + 1;
                sumOfRange += value;
                sumOfSquares += value * value;
            }

            double squareOfSum = sumOfRange * sumOfRange;

            Answer = (int)(squareOfSum - sumOfSquares);

            return 0;
        }
    }
}
