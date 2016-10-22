// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=44</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle044 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and D = |Pk - Pj| is minimised; what is the value of D?";

        /// <summary>
        /// Returns whether the specified number is a pentagonal number.
        /// </summary>
        /// <param name="x">The value to test for being pentagonal.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="x"/> is a pentagonal number; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsPentagonal(int x) => Math.IEEERemainder(Math.Sqrt((24 * x) + 1) + 1, 6) == 0;

        /// <summary>
        /// Returns the pentagonal number for the specified value.
        /// </summary>
        /// <param name="n">The value to calculate the pentagonal number for.</param>
        /// <returns>
        /// The pentagonal number of <paramref name="n"/>.
        /// </returns>
        internal static int Pentagonal(int n) => n * ((3 * n) - 1) / 2;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            for (int k = 1; Answer == null; k++)
            {
                int pk = Pentagonal(k);

                for (int j = k - 1; j > 0; j--)
                {
                    int pj = Pentagonal(j);

                    if (IsPentagonal(pj + pk) && IsPentagonal(pk - pj))
                    {
                        Answer = pk - pj;
                        break;
                    }
                }
            }

            return 0;
        }
    }
}
