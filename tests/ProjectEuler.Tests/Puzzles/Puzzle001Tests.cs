// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle001"/> class.
    /// </summary>
    public static class Puzzle001Tests
    {
        [Theory]
        [InlineData("10", 23)]
        [InlineData("1000", 233168)]
        public static void Puzzle001_Returns_Correct_Solution(string maximum, int expected)
        {
            // Arrange
            string[] args = new[] { maximum };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle001>(args, expected);
        }

        [Fact]
        public static void Puzzle001_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle001>(args);
        }

        [Fact]
        public static void Puzzle001_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "0" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle001>(args);
        }
    }
}
