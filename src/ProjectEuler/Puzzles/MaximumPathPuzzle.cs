// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// The base class for the maximum path sum puzzles.
/// </summary>
public abstract class MaximumPathPuzzle : Puzzle
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
        var working = triangle
            .Select((p) => p as IList<int>)
            .ToList();

        // Work through the triangle from the bottom up until there is one number left
        while (working.Count > 1)
        {
            // Get the bottom two rows of the triangle
            var upper = working[^2];
            var lower = working[^1];

            var maximums = new List<int>(upper.Count);

            for (int i = 0; i < upper.Count; i++)
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
            working.Add(maximums);
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
    protected int[][] LoadTriangle()
    {
        var triangle = new List<int[]>();

        int lines = 0;

        using var stream = ReadResource();
        using var reader = new StreamReader(stream);

        string? line = null;

        while (!string.IsNullOrEmpty(line = reader.ReadLine()))
        {
            string[] split = line.Split(' ');

            var values = split.Select((p) => int.Parse(p, CultureInfo.InvariantCulture)).ToArray();

            triangle.Add(values);
            lines++;
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
