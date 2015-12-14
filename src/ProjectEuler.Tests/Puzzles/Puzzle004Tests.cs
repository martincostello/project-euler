// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle004"/> class.
    /// </summary>
    public static class Puzzle004Tests
    {
        [Theory]
        [InlineData("2", 9009)]
        [InlineData("3", 906609)]
        public static void Puzzle004_Returns_Correct_Solution(string digits, int expected)
        {
            // Arrange
            string[] args = new[] { digits };

            Puzzle004 target = new Puzzle004();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(0, actual);
            Assert.Equal(expected, target.Answer);
        }

        [Fact]
        public static void Puzzle004_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            Puzzle004 target = new Puzzle004();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Puzzle004_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "1" };

            Puzzle004 target = new Puzzle004();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }
    }
}
