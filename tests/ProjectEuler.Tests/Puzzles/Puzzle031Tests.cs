// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle031"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle031Tests
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 2)]
    [InlineData("4", 3)]
    [InlineData("200", 73682)]
    public static void Puzzle031_Returns_Correct_Solution(string total, int expected)
    {
        // Arrange
        string[] args = new[] { total };

        // Act and Assert
        Puzzles.AssertSolution<Puzzle031>(args, expected);
    }

    [Fact]
    public static void Puzzle031_Returns_Minus_One_If_Total_Is_Invalid()
    {
        // Arrange
        string[] args = new[] { "a" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle031>(args);
    }

    [Fact]
    public static void Puzzle031_Returns_Minus_One_If_Total_Is_Too_Small()
    {
        // Arrange
        string[] args = new[] { "-1" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle031>(args);
    }
}
