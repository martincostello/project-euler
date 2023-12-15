// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle016"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle016Tests
{
    [Theory]
    [InlineData("0", 1)]
    [InlineData("1", 2)]
    [InlineData("2", 4)]
    [InlineData("3", 8)]
    [InlineData("4", 7)]
    [InlineData("5", 5)]
    [InlineData("15", 26)]
    [InlineData("1000", 1366)]
    public static void Puzzle016_Returns_Correct_Solution(string power, int expected)
    {
        // Arrange
        string[] args = [power];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle016>(args, expected);
    }

    [Fact]
    public static void Puzzle016_Returns_Minus_One_If_Power_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle016>(args);
    }

    [Fact]
    public static void Puzzle016_Returns_Minus_One_If_Power_Is_Too_Small()
    {
        // Arrange
        string[] args = ["-1"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle016>(args);
    }
}
