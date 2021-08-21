// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle035"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle035Tests
{
    [Theory]
    [InlineData("100", 13)]
    [InlineData("1000000", 55)]
    public static void Puzzle035_Returns_Correct_Solution(string maximum, int expected)
    {
        // Arrange
        var args = new[] { maximum };

        // Act and Assert
        Puzzles.AssertSolution<Puzzle035>(args, expected);
    }

    [Theory]
    [InlineData(197, new long[] { 197, 971, 719 })]
    public static void Puzzle035_GetRotations_Returns_Correct_Values(int value, IEnumerable<long> expected)
    {
        // Act
        IEnumerable<long> actual = Puzzle035.GetRotations(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void Puzzle035_Returns_Minus_One_If_Maximum_Is_Invalid()
    {
        // Arrange
        string[] args = new[] { "a" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle035>(args);
    }

    [Fact]
    public static void Puzzle035_Returns_Minus_One_If_Maximum_Is_Too_Small()
    {
        // Arrange
        string[] args = new[] { "1" };

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle035>(args);
    }
}
