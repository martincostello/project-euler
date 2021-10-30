// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle007"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle007Tests
{
    [Theory]
    [InlineData("6", 13)]
    [InlineData("10001", 104743)]
    public static void Puzzle007_Returns_Correct_Solution(string value, int expected)
    {
        // Arrange
        string[] args = new[] { value };

        // Act and Assert
        Puzzles.AssertSolution<Puzzle007>(args, expected);
    }

    [Fact]
    public static void Puzzle007_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
    {
        // Arrange
        string[] args = new[] { "a" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle007>(args);
    }

    [Fact]
    public static void Puzzle007_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
    {
        // Arrange
        string[] args = new[] { "0" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle007>(args);
    }
}
