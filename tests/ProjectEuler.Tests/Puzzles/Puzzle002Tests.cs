// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle002"/> class.
/// </summary>
public static class Puzzle002Tests
{
    [Theory]
    [InlineData("100", 44)]
    [InlineData("4000000", 4613732)]
#pragma warning disable xUnit1026
    public static void Puzzle002_Returns_Correct_Solution(string maximum, int expected)
#pragma warning restore xUnit1026
    {
        // Arrange
        string[] args = [maximum];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle002>(args, expected);
    }

    [Fact]
    public static void Puzzle002_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle002>(args);
    }

    [Fact]
    public static void Puzzle002_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
    {
        // Arrange
        string[] args = ["0"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle002>(args);
    }
}
