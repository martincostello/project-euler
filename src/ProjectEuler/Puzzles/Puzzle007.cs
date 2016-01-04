// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Globalization;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=7</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle007 : Puzzle
    {
        public override string Question => "What is the prime number with the specified ordinal number?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int numbers;

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out numbers) ||
                numbers < 1)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            int primesFound = 0;

            for (int i = 2; primesFound < numbers; i++)
            {
                if (Maths.IsPrime(i))
                {
                    primesFound++;
                    Answer = i;
                }
            }

            return 0;
        }
    }
}
