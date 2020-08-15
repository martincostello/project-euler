// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=27</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle027 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.";

        /// <summary>
        /// Returns the number of primes for consecutive values of n, starting with n = 0,
        /// for the specified values of the a and b coefficients of the quadratic formula.
        /// </summary>
        /// <param name="a">The value of the coefficient 'a'.</param>
        /// <param name="b">The value of the coefficient 'b'.</param>
        /// <returns>
        /// The number of primes for consecutive values of n for the coefficient values
        /// specified by <paramref name="a"/> and <paramref name="b"/>.
        /// </returns>
        internal static int PrimesForQuadraticCoefficients(int a, int b)
        {
            int count = 0;

            for (int n = 0; ; n++)
            {
                int value = Quadratic(n, a, b);

                if (!Maths.IsPrime(value))
                {
                    break;
                }

                count++;
            }

            return count;
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            const int Maximum = 1000;

            int bestCount = 0;
            int product = 0;

            int seed = (Maximum - 1) * -1;

            for (int a = seed; a < Maximum; a++)
            {
                for (int b = seed; b < Maximum; b++)
                {
                    int count = PrimesForQuadraticCoefficients(a, b);

                    if (count > bestCount)
                    {
                        bestCount = count;
                        product = a * b;
                    }
                }
            }

            Answer = product;

            return 0;
        }

        /// <summary>
        /// Returns the result of the quadratic value for the specified values.
        /// </summary>
        /// <param name="n">The value to use for the forumula.</param>
        /// <param name="a">The value of the coefficient 'a'.</param>
        /// <param name="b">The value of the coefficient 'b'.</param>
        /// <returns>
        /// The result of the formula for <paramref name="n"/>, <paramref name="a"/> and <paramref name="b"/>.
        /// </returns>
        private static int Quadratic(int n, int a, int b) => (n * n) + (a * n) + b;
    }
}
