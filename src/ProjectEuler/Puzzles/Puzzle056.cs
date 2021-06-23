// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Numerics;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=56</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle056 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the maximum digital sum?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int maximumSum = 0;

            const int Limit = 100;

            for (int a = 0; a < Limit; a++)
            {
                for (int b = 0; b < Limit; b++)
                {
                    BigInteger value = BigInteger.Pow(a, b);

                    var digits = Maths.Digits(value);

                    maximumSum = Math.Max(maximumSum, digits.Sum());
                }
            }

            Answer = maximumSum;

            return 0;
        }
    }
}
