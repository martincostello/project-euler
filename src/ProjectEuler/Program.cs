// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A console application that solves puzzles for <c>https://projecteuler.net/</c>. This class cannot be inherited.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry-point to the application.
        /// </summary>
        /// <param name="args">The arguments to the application.</param>
        /// <returns>The exit code from the application.</returns>
        internal static int Main(string[] args)
        {
            if (args == null || args.Length < 1)
            {
                Console.Error.WriteLine("No puzzle specified.");
                return -1;
            }

            int puzzle;
            Type type = null;

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out puzzle) ||
                puzzle < 1 ||
                (type = GetPuzzleType(puzzle)) == null)
            {
                Console.Error.WriteLine("The puzzle number specified is invalid.");
                return -1;
            }

            args = args.Skip(1).ToArray();

            return SolvePuzzle(type, args);
        }

        /// <summary>
        /// Solves the puzzle associated with the specified type.
        /// </summary>
        /// <param name="type">The type of the puzzle.</param>
        /// <param name="args">The arguments to pass to the puzzle.</param>
        /// <returns>
        /// The value returned by <see cref="IPuzzle.Solve"/>.
        /// </returns>
        internal static int SolvePuzzle(Type type, string[] args)
        {
            IPuzzle puzzle = Activator.CreateInstance(type, nonPublic: true) as IPuzzle;

            Console.WriteLine();
            Console.WriteLine("Project Euler - Puzzle {0}", type.Name.Replace("Puzzle", string.Empty).TrimStart('0'));
            Console.WriteLine();

            Console.WriteLine(puzzle.Question);

            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = puzzle.Solve(args);

            if (result == 0)
            {
                stopwatch.Stop();

                Console.WriteLine();
                Console.WriteLine("Answer: {0}", puzzle.Answer);
                Console.WriteLine();
                Console.WriteLine("Took {0:N2} seconds.", stopwatch.Elapsed.TotalSeconds);
            }

            return result;
        }

        /// <summary>
        /// Gets the puzzle type to use for the specified number.
        /// </summary>
        /// <param name="number">The number of the puzzle to get the type for.</param>
        /// <returns>
        /// The <see cref="Type"/> for the specified puzzle number, if found; otherwise <see langword="null"/>.
        /// </returns>
        private static Type GetPuzzleType(int number)
        {
            string typeName = string.Format(
                CultureInfo.InvariantCulture,
                "MartinCostello.ProjectEuler.Puzzles.Puzzle{0:000}",
                number);

            return Type.GetType(typeName);
        }
    }
}
