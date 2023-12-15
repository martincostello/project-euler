// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle020"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle020Tests
{
    [Theory]
    [InlineData("0", 1)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 6)]
    [InlineData("4", 6)]
    [InlineData("10", 27)]
    [InlineData("100", 648)]
    public static void Puzzle020_Returns_Correct_Solution(string number, int expected)
    {
        // Arrange
        string[] args = [number];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle020>(args, expected);
    }

    [Fact]
    public static void Puzzle020_Returns_Minus_One_If_Number_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle020>(args);
    }

    [Fact]
    public static void Puzzle020_Returns_Minus_One_If_Number_Is_Too_Small()
    {
        // Arrange
        string[] args = ["-1"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle020>(args);
    }
}
