// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=2</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle002 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "By considering the terms in the Fibonacci sequence starting with 1 and 2 whose values do not exceed the specified value, what is the sum of the even-valued terms?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int max) || max < 1)
            {
                Console.WriteLine("The specified maximum value is invalid.");
                return -1;
            }

            var fibonacciValues = new List<int>() { 1, 2 };

            while (true)
            {
                int count = fibonacciValues.Count;
                int next = fibonacciValues[count - 1] + fibonacciValues[count - 2];

                if (next > max)
                {
                    break;
                }

                fibonacciValues.Add(next);
            }

            int answer = 0;

            for (int i = 0; i < fibonacciValues.Count; i++)
            {
                int number = fibonacciValues[i];

                if (number % 2 == 0)
                {
                    answer += number;
                }
            }

            Answer = answer;

            return 0;
        }
    }
}
