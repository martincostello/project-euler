// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

#pragma warning disable SA1010

/// <summary>
/// A class containing tests for the <see cref="Puzzle029"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle029Tests
{
    [Theory]
    [InlineData(5, new double[] { 4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125 })]
    public static void Puzzle029_GeneratePowerSequence_Returns_Correct_Sequence(int maximum, IEnumerable<double> expected)
    {
        // Act
        ICollection<double> actual = Puzzle029.GeneratePowerSequence(maximum);

        // Assert
        Assert.Equal(expected, actual.Order());
    }

    [Theory]
    [InlineData("5", 15)]
    [InlineData("100", 9183)]
#pragma warning disable xUnit1026
    public static void Puzzle029_Returns_Correct_Solution(string maximum, int expected)
#pragma warning restore xUnit1026
    {
        // Arrange
        string[] args = [maximum];

        // Act and Assert
        Puzzles.AssertSolution<Puzzle029>(args, expected);
    }

    [Fact]
    public static void Puzzle029_Returns_Minus_One_If_Number_Is_Invalid()
    {
        // Arrange
        string[] args = ["a"];

        // Act and Assert
        Puzzles.AssertInvalid<Puzzle029>(args);
    }
}
