// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle047"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle047Tests
    {
        [Theory]
        [InlineData("2", 14)]
        [InlineData("3", 644)]
        [InlineData("4", 134043)]
        public static void Puzzle047_Returns_Correct_Solution(string factors, int expected)
        {
            // Arrange
            string[] args = new[] { factors };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle047>(args, expected);
        }

        [Fact]
        public static void Puzzle047_Returns_Minus_One_If_Factors_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle047>(args);
        }

        [Fact]
        public static void Puzzle047_Returns_Minus_One_If_Factors_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "1" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle047>(args);
        }
    }
}
