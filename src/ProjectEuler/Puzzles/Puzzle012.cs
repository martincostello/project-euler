// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=12</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle012 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the value of the first triangle number to have the specified number of divisors?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int divisors) || divisors < 1)
            {
                Console.WriteLine("The specified number of divisors is invalid.");
                return -1;
            }

            long triangleNumber = 0;

            for (int n = 1; ; n++)
            {
                triangleNumber += n;

                int numberOfFactors = 0;
                using var enumerator = Maths.GetFactorsUnordered(triangleNumber).GetEnumerator();

                while (enumerator.MoveNext() && numberOfFactors < divisors)
                {
                    numberOfFactors++;
                }

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
