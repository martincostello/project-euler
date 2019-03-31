// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=7</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle007 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the prime number with the specified ordinal number?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int numbers) || numbers < 1)
            {
                Console.WriteLine("The specified number is invalid.");
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
