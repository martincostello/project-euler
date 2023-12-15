// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle048"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle048Tests
{
    [Theory]
    [InlineData("10", "0405071317")]
    [InlineData("1000", "9110846700")]
    public static void Puzzle048_Returns_Correct_Solution(string maximum, string expected)
    {
        // Arrange
        string[] args = [maximum];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle048>(args, expected);
    }

    [Fact]
    public static void Puzzle048_Returns_Minus_One_If_Maximum_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle048>(args);
    }

    [Fact]
    public static void Puzzle048_Returns_Minus_One_If_Maximum_Is_Too_Small()
    {
        // Arrange
        string[] args = ["1"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle048>(args);
    }
}
