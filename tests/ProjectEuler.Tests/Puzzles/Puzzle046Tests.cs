// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle046"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle046Tests
{
    [Theory]
    [InlineData(9, true)]
    [InlineData(15, true)]
    [InlineData(21, true)]
    [InlineData(25, true)]
    [InlineData(27, true)]
    [InlineData(33, true)]
    [InlineData(35, true)]
    [InlineData(37, true)]
    public static void Puzzle046_CanBeWrittenAsTheSumOfAPrimeAndTwiceASquare_Returns_Correct_Result(int value, bool expected)
    {
        // Act
        bool actual = Puzzle046.CanBeWrittenAsTheSumOfAPrimeAndTwiceASquare(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void Puzzle046_Returns_Correct_Solution()
    {
        // Arrange
        int expected = 5777;

        // Act and Assert
        Puzzles.AssertSolution<Puzzle046>(expected);
    }
}
