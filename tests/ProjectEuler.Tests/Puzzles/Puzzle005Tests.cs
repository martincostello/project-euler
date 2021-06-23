// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle005"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle005Tests
    {
        [Theory]
        [InlineData("2", 2)]
        [InlineData("3", 6)]
        [InlineData("4", 12)]
        [InlineData("10", 2520)]
        [InlineData("20", 232792560)]
        public static void Puzzle005_Returns_Correct_Solution(string max, int expected)
        {
            // Arrange
            string[] args = new[] { max };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle005>(args, expected);
        }

        [Fact]
        public static void Puzzle005_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle005>(args);
        }

        [Fact]
        public static void Puzzle005_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "1" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle005>(args);
        }
    }
}
