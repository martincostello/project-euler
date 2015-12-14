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

            Puzzle001 target = new Puzzle001();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(0, actual);
            Assert.Equal(expected, target.Answer);
        }

        [Fact]
        public static void Puzzle001_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            Puzzle001 target = new Puzzle001();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Puzzle001_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "0" };

            Puzzle001 target = new Puzzle001();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }
    }
}
