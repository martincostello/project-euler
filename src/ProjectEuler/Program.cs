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

            int day;
            IPuzzle puzzle = null;

            if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out day) ||
                day < 1 ||
                (puzzle = GetPuzzle(day)) == null)
            {
                Console.Error.WriteLine("The puzzle number specified is invalid.");
                return -1;
            }

            Console.WriteLine();
            Console.WriteLine("Project Euler - Day {0}", day);
            Console.WriteLine();

            args = args.Skip(1).ToArray();

            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = puzzle.Solve(args);

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine("Took {0:N2} seconds.", stopwatch.Elapsed.TotalSeconds);

            return result;
        }

        /// <summary>
        /// Gets the puzzle to use for the specified day.
        /// </summary>
        /// <param name="day">The day to get the puzzle for.</param>
        /// <returns>The <see cref="IPuzzle"/> for the specified day.</returns>
        private static IPuzzle GetPuzzle(int day)
        {
            string typeName = string.Format(
                CultureInfo.InvariantCulture,
                "MartinCostello.ProjectEuler.Puzzles.Puzzle{0:000}",
                day);

            Type type = Type.GetType(typeName);

            if (type == null)
            {
                return null;
            }

            return Activator.CreateInstance(type, nonPublic: true) as IPuzzle;
        }
    }
}
