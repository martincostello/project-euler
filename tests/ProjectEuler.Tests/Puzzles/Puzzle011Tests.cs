// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle011"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle011Tests
{
    [Fact]
    public static void Puzzle011_Returns_Correct_Solution()
    {
        // Arrange
        object expected = 70_600_674;

        // Act and Assert
        Puzzles.AssertSolution<Puzzle011>(expected);
        Puzzles.AssertSolution<Puzzle011>(expected);
    }
}
