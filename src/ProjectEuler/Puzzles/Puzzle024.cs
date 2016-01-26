// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=24</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle024 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the millionth lexicographic permutation of the digits 0-9?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            var collection = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var millionthPermutation = Maths.Permutations(collection)
                .Skip(999999)
                .First()
                .ToList();

            Answer = Maths.FromDigits(millionthPermutation);

            return 0;
        }
    }
}
