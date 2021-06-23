// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=55</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle055 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "How many Lychrel numbers are there below ten-thousand?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int lychrelNumbers = 0;

            const int Iterations = 50;
            const int Limit = 10_000;

            for (long i = 1; i < Limit; i++)
            {
                long number = i;

                bool found = false;

                for (int j = 0; j < Iterations; j++)
                {
                    var digits = Maths.Digits(number);
                    var reverse = digits.Reverse().ToArray();

                    long sum = number + Maths.FromDigits(reverse);

                    digits = Maths.Digits(sum);

                    if (Helpers.IsPalindromic(digits))
                    {
                        found = true;
                        break;
                    }

                    number = sum;
                }

                if (!found)
                {
                    lychrelNumbers++;
                }
            }

            Answer = lychrelNumbers;

            return 0;
        }
    }
}
