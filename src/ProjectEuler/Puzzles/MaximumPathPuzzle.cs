// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The base class for the maximum path sum puzzles.
    /// </summary>
    internal abstract class MaximumPathPuzzle : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the maximum total from top to bottom of the triangle.";

        /// <summary>
        /// Computes the maximum path sum for the specified path triangle.
        /// </summary>
        /// <param name="triangle">A two-dimensional array containing the path triangle.</param>
        /// <returns>
        /// The maximum path sum for <paramref name="triangle"/>.
        /// </returns>
        internal static int ComputeMaximumPathSum(int[][] triangle)
        {
            List<int[]> working = triangle.ToList();

            // Work through the triangle from the bottom up until there is one number left
            while (working.Count > 1)
            {
                // Get the bottom two rows of the triangle
                int[] upper = working[working.Count - 2];
                int[] lower = working[working.Count - 1];

                List<int> maximums = new List<int>();

                for (int i = 0; i < upper.Length; i++)
                {
                    // Find the maximum value of two adjacent values
                    int max = Math.Max(lower[i], lower[i + 1]);

                    // Build up a replacement for the upper row that
                    // contains the sum of the original value and the
                    // larger of the two values below it in the lower one.
                    maximums.Add(max + upper[i]);
                }

                // Remove the existing bottom two rows
                working.RemoveAt(working.Count - 1);
                working.RemoveAt(working.Count - 1);

                // Add the maximums as the new bottom row
                working.Add(maximums.ToArray());
            }

            // The single value left is the maximum path sum
            return working[0][0];
        }

        /// <summary>
        /// Loads the path triangle for the puzzle.
        /// </summary>
        /// <returns>
        /// A jagged array representing the values of the path triangle for the puzzle.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2202:Do not dispose objects multiple times",
            Justification = "The stream is not disposed of multiple times.")]
        protected int[][] LoadTriangle()
        {
            List<int[]> triangle = new List<int[]>();

            int lines = 0;

            using (Stream stream = ReadResource())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = null;

                    while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                    {
                        string[] split = line.Split(' ');

                        var values = split.Select((p) => int.Parse(p, CultureInfo.InvariantCulture)).ToArray();

                        triangle.Add(values);
                        lines++;
                    }
                }
            }

            return triangle.ToArray();
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int[][] triangle = LoadTriangle();

            Answer = ComputeMaximumPathSum(triangle);

            return 0;
        }
    }
}
