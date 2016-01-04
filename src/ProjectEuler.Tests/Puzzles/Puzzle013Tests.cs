// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle013"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle013Tests
    {
        [Fact]
        public static void Puzzle013_Returns_Correct_Solution()
        {
            // Arrange
            object expected = "5537376230";

            // Act and Assert
            Puzzles.AssertSolution<Puzzle013>(expected);
        }

        [Theory]
        [InlineData(new[] { "0", "0", "0", "0", }, 0, 0)]
        [InlineData(new[] { "01", "02", "03", "04", }, 0, 0)]
        [InlineData(new[] { "01", "02", "03", "04", }, 1, 10)]
        [InlineData(new[] { "14", "23", "32", "41", }, 0, 10)]
        [InlineData(new[] { "14", "23", "32", "41", }, 1, 10)]
        [InlineData(new[] { "09", "03", "01", "06", }, 0, 0)]
        [InlineData(new[] { "09", "03", "01", "06", }, 1, 19)]
        [InlineData(new[] { "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9", "9" }, 0, 108)]
        public static void Puzzle013_Sum_Returns_Correct_Value(string[] collection, int index, int expected)
        {
            // Act
            int actual = Puzzle013.Sum(collection, index);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
