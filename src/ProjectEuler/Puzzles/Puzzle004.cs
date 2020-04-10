// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=4</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle004 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the largest palindrome made from the product of two numbers with the specified number of digits?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int digitCount) || digitCount < 2)
            {
                Console.WriteLine("The specified number of digits is invalid.");
                return -1;
            }

            var palindromes = new SortedSet<int>();

            int seed = (int)Math.Pow(10, digitCount - 1);
            int limit = (int)Math.Pow(10, digitCount);

            for (int i = seed; i < limit; i++)
            {
                for (int j = seed; j < i + 1; j++)
                {
                    int product = i * j;
                    IReadOnlyList<int> digits = Maths.Digits(product);

                    if (Helpers.IsPalindromic(digits))
                    {
                        palindromes.Add(product);
                    }
                }
            }

            Answer = palindromes.Max;

            return 0;
        }
    }
}
