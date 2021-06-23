// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=15</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle015 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "How many routes are there through a square grid with the specified number of sides?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int sides) || sides < 1)
            {
                Console.WriteLine("The specified number of sides is invalid.");
                return -1;
            }

            Answer = Maths.Binomial(2 * sides, sides);

            return 0;
        }
    }
}
