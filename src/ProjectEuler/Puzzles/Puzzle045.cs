// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=45</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle045 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the second triangle number that is also pentagonal and hexagonal?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            const int FirstHexagonalNumber = 143;

            for (long n = FirstHexagonalNumber + 1; n < long.MaxValue; n++)
            {
                long x = Maths.Hexagonal(n);

                if (Maths.IsPentagonal(x))
                {
                    Answer = x;
                    break;
                }
            }

            return 0;
        }
    }
}
