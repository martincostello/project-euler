// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle006"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle006Tests
    {
        [Theory]
        [InlineData("10", 2640)]
        [InlineData("100", 25164150)]
        public static void Puzzle006_Returns_Correct_Solution(string value, int expected)
        {
            // Arrange
            string[] args = new[] { value };
            var target = new Puzzle006();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(0, actual);
            Assert.Equal(expected, target.Answer);
        }

        [Fact]
        public static void Puzzle006_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };
            var target = new Puzzle006();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Puzzle006_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "0" };
            var target = new Puzzle006();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }
    }
}
