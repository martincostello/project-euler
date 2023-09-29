// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="MaximumPathPuzzle"/> class.
/// </summary>
public static class MaximumPathPuzzleTests
{
    [Fact]
    public static void MaximumPathPuzzle_ComputeMaximumPathSum_Returns_Correct_Value()
    {
        // Arrange
        int expected = 23;

        int[][] triangle =
        [
            [3],
            [7, 4],
            [2, 4, 6],
            [8, 5, 9, 3],
        ];

        // Act
        int actual = MaximumPathPuzzle.ComputeMaximumPathSum(triangle);

        // Asset
        Assert.Equal(expected, actual);
    }
}
