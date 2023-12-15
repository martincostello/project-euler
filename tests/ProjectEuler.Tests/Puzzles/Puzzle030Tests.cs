// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle030"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle030Tests
{
    [Theory]
    [InlineData(10, 4, false)]
    [InlineData(1634, 4, true)]
    [InlineData(8208, 4, true)]
    [InlineData(9474, 4, true)]
    [InlineData(4150, 5, true)]
    [InlineData(4151, 5, true)]
    [InlineData(54748, 5, true)]
    [InlineData(92727, 5, true)]
    [InlineData(93084, 5, true)]
    [InlineData(194979, 5, true)]
    public static void Puzzle030_IsSumOfDigitPowers_Returns_Correct_Value(int value, int power, bool expected)
    {
        // Act
        bool actual = Puzzle030.IsSumOfDigitPowers(value, power);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("4", 19316)]
    [InlineData("5", 443839)]
    public static void Puzzle030_Returns_Correct_Solution(string power, int expected)
    {
        // Arrange
        string[] args = [power];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle030>(args, expected);
    }

    [Fact]
    public static void Puzzle030_Returns_Minus_One_If_Power_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle030>(args);
    }

    [Fact]
    public static void Puzzle030_Returns_Minus_One_If_Power_Is_Too_Small()
    {
        // Arrange
        string[] args = ["-1"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle030>(args);
    }
}
