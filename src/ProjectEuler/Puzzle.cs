// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The base class for puzzles.
    /// </summary>
    internal abstract class Puzzle : IPuzzle
    {
        /// <inheritdoc />
        public abstract string Question { get; }

        /// <inheritdoc />
        public object Answer { get; protected set; }

        /// <summary>
        /// Gets the minimum number of arguments required to solve the puzzle.
        /// </summary>
        protected virtual int MinimumArguments => 0;

        /// <inheritdoc />
        public virtual int Solve(string[] args)
        {
            if (!EnsureArguments(args, MinimumArguments))
            {
                Console.Error.WriteLine(
                    "At least {0:N0} argument{1} {2} required.",
                    MinimumArguments,
                    MinimumArguments == 1 ? string.Empty : "s",
                    MinimumArguments == 1 ? "is" : "are");

                return -1;
            }

            return SolveCore(args);
        }

        /// <summary>
        /// Ensures that the specified number of arguments are present.
        /// </summary>
        /// <param name="args">The input arguments to the puzzle.</param>
        /// <param name="minimumLength">The minimum number of arguments required.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="args"/> is at least
        /// <paramref name="minimumLength"/> in length; otherwise <see langword="false"/>.
        /// </returns>
        protected static bool EnsureArguments(ICollection<string> args, int minimumLength)
        {
            return args.Count >= minimumLength;
        }

        /// <summary>
        /// Solves the puzzle given the specified arguments.
        /// </summary>
        /// <param name="args">The input arguments to the puzzle.</param>
        /// <returns>The exit code the application should return.</returns>
        protected abstract int SolveCore(string[] args);
    }
}
