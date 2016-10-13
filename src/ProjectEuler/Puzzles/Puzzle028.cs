// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=28</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle028 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the sum of the numbers on the diagonals in a square spiral with the specified number of sides?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int sides;

            if (!TryParseInt32(args[0], out sides) || sides < 1 || sides % 2 == 0)
            {
                Console.WriteLine("The specified number of sides is invalid.");
                return -1;
            }

            int sum = 1;
            int ringStart = 2;

            for (int sideLength = 3; ringStart < sides * sides; sideLength += 2)
            {
                int lastCorner = sideLength * sideLength;
                int thirdCorner = lastCorner - sideLength + 1;
                int secondCorner = thirdCorner - sideLength + 1;
                int firstCorner = secondCorner - sideLength + 1;

                sum += firstCorner;
                sum += secondCorner;
                sum += thirdCorner;
                sum += lastCorner;

                ringStart = lastCorner + 1;
            }

            Answer = sum;

            return 0;
        }
    }
}
