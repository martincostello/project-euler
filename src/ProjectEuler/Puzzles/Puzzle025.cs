// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Collections.Generic;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=25</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle025 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the number of the first term in the Fibonacci sequence to contain 1,000 digits?";

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> of <see cref="string"/> that enumerates the Fibonacci sequence.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="string"/> that enumerates the Fibonacci sequence.
        /// </returns>
        internal static IEnumerable<string> Fibonacci()
        {
            List<string> sequence = new List<string>() { "1", "1" };

            foreach (string value in sequence)
            {
                yield return value;
            }

            for (int i = 2; ; i++)
            {
                string value = Maths.Add(sequence[i - 1], sequence[i - 2]);

                yield return value;

                sequence.Add(value);
            }
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int index = 0;

            foreach (string value in Fibonacci())
            {
                index++;

                if (value.Length == 1000)
                {
                    Answer = index;
                    break;
                }
            }

            return 0;
        }
    }
}
