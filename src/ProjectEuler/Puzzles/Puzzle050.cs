// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=50</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle050 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Which prime, below the specified value, can be written as the sum of the most consecutive primes?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int maximum) || maximum < 6)
            {
                Console.WriteLine("The specified number is invalid.");
                return -1;
            }

            var primes = new HashSet<int>(Maths.Primes(maximum));

            var cumulativeSum = Maths.CumulativeSum(primes).ToList();
            cumulativeSum.Insert(0, 0);

            int primeCount = 0;
            int answer = 0;

            for (int i = primeCount; i < cumulativeSum.Count; i++)
            {
                for (int j = i - (primeCount + 1); j >= 0; j--)
                {
                    int prime1 = cumulativeSum[i];
                    int prime2 = cumulativeSum[j];
                    int delta = prime1 - prime2;

                    if (delta > maximum)
                    {
                        break;
                    }

                    if (primes.Contains(delta))
                    {
                        primeCount = i - j;
                        answer = delta;
                    }
                }
            }

            Answer = answer;

            return 0;
        }
    }
}
