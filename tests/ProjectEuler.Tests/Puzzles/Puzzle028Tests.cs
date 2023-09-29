// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

#pragma warning disable SA1010

/// <summary>
/// A class containing tests for the <see cref="Puzzle028"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle028Tests
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("3", 25)]
    [InlineData("5", 101)]
    [InlineData("7", 261)]
    [InlineData("1001", 669171001)]
#pragma warning disable xUnit1026
    public static void Puzzle028_Returns_Correct_Solution(string sides, int expected)
#pragma warning restore xUnit1026
    {
        // Arrange
        string[] args = [sides];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle028>(args, expected);
    }

    [Fact]
    public static void Puzzle028_Returns_Minus_One_If_Sides_Value_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle028>(args);
    }

    [Fact]
    public static void Puzzle028_Returns_Minus_One_If_Sides_Value_Is_Too_Small()
    {
        // Arrange
        string[] args = ["0"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle028>(args);
    }

    [Fact]
    public static void Puzzle028_Returns_Minus_One_If_Sides_Value_Is_Even()
    {
        // Arrange
        string[] args = ["2"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle028>(args);
    }
}
