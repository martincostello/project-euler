// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle015"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle015Tests
    {
        [Theory]
        [InlineData("1", 2)]
        [InlineData("2", 6)]
        [InlineData("20", 137846528820)]
        public static void Puzzle015_Returns_Correct_Solution(string divisors, long expected)
        {
            // Arrange
            string[] args = new[] { divisors };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle015>(args, expected);
        }

        [Fact]
        public static void Puzzle015_Returns_Minus_One_If_Sides_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle015>(args);
        }

        [Fact]
        public static void Puzzle015_Returns_Minus_One_If_Sides_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "0" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle015>(args);
        }
    }
}
