// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=44</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle044 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and D = |Pk - Pj| is minimised; what is the value of D?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            for (long k = 1; Answer == null; k++)
            {
                long pk = Maths.Pentagonal(k);

                for (long j = k - 1; j > 0; j--)
                {
                    long pj = Maths.Pentagonal(j);

                    if (Maths.IsPentagonal(pj + pk) && Maths.IsPentagonal(pk - pj))
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
