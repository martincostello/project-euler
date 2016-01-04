// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=4</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle004 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the largest palindrome made from the product of two numbers with the specified number of digits?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int digits;

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out digits) ||
                digits < 2)
            {
                Console.Error.WriteLine("The specified number of digits is invalid.");
                return -1;
            }

            var palindromes = new List<int>();

            for (int i = (int)Math.Pow(10, digits - 1); i < Math.Pow(10, digits); i++)
            {
                for (int j = (int)Math.Pow(10, digits - 1); j < i + 1; j++)
                {
                    int product = i * j;

                    char[] chars = product.ToString(CultureInfo.InvariantCulture).ToCharArray();

                    bool isPalindromic = true;

                    for (int k = 0; k < chars.Length / 2; k++)
                    {
                        if (chars[k] != chars[chars.Length - k - 1])
                        {
                            isPalindromic = false;
                            break;
                        }
                    }

                    if (isPalindromic)
                    {
                        palindromes.Add(product);
                    }
                }
            }

            Answer = palindromes.Max();

            return 0;
        }
    }
}
