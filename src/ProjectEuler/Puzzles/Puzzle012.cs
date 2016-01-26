// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=12</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle012 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the value of the first triangle number to have the specified number of divisors?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int divisors;

            if (!TryParseInt32(args[0], out divisors) || divisors < 1)
            {
                Console.Error.WriteLine("The specified number of divisors is invalid.");
                return -1;
            }

            long triangleNumber = 0;

            for (int n = 1; ; n++)
            {
                triangleNumber += n;

                int numberOfFactors = Maths.GetFactors(triangleNumber).Count();

                if (numberOfFactors >= divisors)
                {
                    Answer = triangleNumber;
                    break;
                }
            }

            return 0;
        }
    }
}
