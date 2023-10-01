// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle006"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle006Tests
{
    [Theory]
    [InlineData("10", 2640)]
    [InlineData("100", 25164150)]
#pragma warning disable xUnit1026
    public static void Puzzle006_Returns_Correct_Solution(string value, int expected)
#pragma warning restore xUnit1026
    {
        // Arrange
        string[] args = [value];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle006>(args, expected);
    }

    [Fact]
    public static void Puzzle006_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle006>(args);
    }

    [Fact]
    public static void Puzzle006_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
    {
        // Arrange
        string[] args = ["0"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle006>(args);
    }
}
