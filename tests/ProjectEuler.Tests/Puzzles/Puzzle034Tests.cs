// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle034"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle034Tests
{
    [Theory]
    [InlineData(145, true)]
    [InlineData(146, false)]
    public static void Puzzle034_IsCurious_Returns_Correct_Value(int value, bool expected)
    {
        // Act
        bool actual = Puzzle034.IsCurious(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void Puzzle034_Returns_Correct_Solution()
    {
        // Arrange
        int expected = 40730;

        // Act and Assert
        Puzzles.AssertSolution<Puzzle034>(expected);
    }
}
