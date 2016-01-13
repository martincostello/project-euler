// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Collections.Generic;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=23</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle023 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int sum = 0;

            var abundantNumbers = new List<int>();

            // All integers greater than 28,123 can be written as the sum of two abundant numbers
            const int UpperLimit = 28123;

            for (int n = 1; n <= UpperLimit; n++)
            {
                if (Maths.IsAbundantNumber(n))
                {
                    abundantNumbers.Add(n);
                }

                bool canExpressAsSumOfTwoAbundantNumbers = false;

                if (n % 2 == 0 && abundantNumbers.Contains(n / 2))
                {
                    canExpressAsSumOfTwoAbundantNumbers = true;
                }

                if (!canExpressAsSumOfTwoAbundantNumbers)
                {
                    foreach (int value in abundantNumbers)
                    {
                        if (abundantNumbers.Contains(n - value))
                        {
                            canExpressAsSumOfTwoAbundantNumbers = true;
                            break;
                        }
                    }
                }

                if (!canExpressAsSumOfTwoAbundantNumbers)
                {
                    sum += n;
                }
            }

            Answer = sum;

            return 0;
        }
    }
}
