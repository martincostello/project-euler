// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle045"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle045Tests
{
    [Fact]
    public static void Puzzle045_Returns_Correct_Solution()
    {
        // Arrange
        long expected = 1533776805;

        // Act and Assert
        Puzzles.AssertSolution<Puzzle045>(expected);
    }
}
