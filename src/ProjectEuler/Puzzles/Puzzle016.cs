// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Linq;
    using System.Numerics;

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

            if (!TryParseInt32(args[0], out power) || power < 0)
            {
                Console.WriteLine("The specified number is invalid.");
                return -1;
            }

            BigInteger value = BigInteger.Pow(2, power);

            Answer = Maths.Digits(value).Sum();

            return 0;
        }
    }
}
