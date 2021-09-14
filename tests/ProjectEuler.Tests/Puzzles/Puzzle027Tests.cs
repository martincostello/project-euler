// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle027"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle027Tests
{
    [Theory]
    [InlineData(1, 41, 40)]
    [InlineData(-79, 1601, 80)]
    public static void Puzzle027_PrimesForQuadraticCoefficients_Returns_Correct_Value(int a, int b, int expected)
    {
        // Act
        int actual = Puzzle027.PrimesForQuadraticCoefficients(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void Puzzle027_Returns_Correct_Solution()
    {
        // Arrange
        int expected = -59231;

        // Act and Assert
        Puzzles.AssertSolution<Puzzle027>(expected);
    }
}
