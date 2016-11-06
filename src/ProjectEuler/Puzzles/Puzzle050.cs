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
    internal sealed class Puzzle050 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Which prime, below the specified value, can be written as the sum of the most consecutive primes?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int maximum;

            if (!TryParseInt32(args[0], out maximum) || maximum < 6)
            {
                Console.WriteLine("The specified number is invalid.");
                return -1;
            }

            IList<int> primes = Maths.Primes(maximum)
                .Reverse()
                .ToList();

            int answer = 0;
            int longestSum = 0;

            foreach (int prime in primes)
            {
                IList<int> lesserPrimes = primes
                    .Where((p) => p < prime)
                    .ToList();

                if (lesserPrimes.Count < 2 ||
                    (longestSum != 0 && lesserPrimes.Count < longestSum))
                {
                    break;
                }

                if (lesserPrimes.Count > longestSum)
                {
                    for (int i = 0; i < lesserPrimes.Count; i++)
                    {
                        IList<int> slice = lesserPrimes
                            .Skip(i)
                            .Reverse()
                            .ToList();

                        int sum = prime;
                        int used = 0;

                        for (int j = 0; j < slice.Count && sum > 0; j++)
                        {
                            sum -= slice[j];
                            used++;
                        }

                        if (sum == 0 && used > longestSum)
                        {
                            answer = prime;
                            longestSum = used;
                            break;
                        }
                    }
                }
            }

            Answer = answer;

            return 0;
        }
    }
}
