// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle097"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle097Tests
{
    [Fact]
    public static void Puzzle097_Returns_Correct_Solution()
    {
        // Arrange
        long expected = 8739992577;

        // Act and Assert
        Puzzles.AssertSolution<Puzzle097>(expected);
    }
}
