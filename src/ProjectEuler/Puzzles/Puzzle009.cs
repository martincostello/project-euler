// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=9</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle009 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            const int Limit = 1000;

            for (int a = 1; a < Limit; a++)
            {
                for (int b = 1; b < Limit; b++)
                {
                    if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(Limit - a - b, 2))
                    {
                        Answer = a * b * (Limit - a - b);
                        break;
                    }
                }
            }

            return 0;
        }
    }
}
