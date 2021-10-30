// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle012"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle012Tests
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 3)]
    [InlineData("3", 6)]
    [InlineData("4", 6)]
    [InlineData("5", 28)]
    [InlineData("6", 28)]
    [InlineData("500", 76576500)]
    public static void Puzzle012_Returns_Correct_Solution(string divisors, long expected)
    {
        // Arrange
        string[] args = new[] { divisors };

        // Act and Assert
        Puzzles.AssertSolution<Puzzle012>(args, expected);
    }

    [Fact]
    public static void Puzzle012_Returns_Minus_One_If_Divisors_Value_Is_Invalid()
    {
        // Arrange
        string[] args = new[] { "a" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle012>(args);
    }

    [Fact]
    public static void Puzzle012_Returns_Minus_One_If_Divisors_Value_Is_Too_Small()
    {
        // Arrange
        string[] args = new[] { "0" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle012>(args);
    }
}
