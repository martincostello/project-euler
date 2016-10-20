// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle042"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle042Tests
    {
        [Theory]
        [InlineData("A", 1)]
        [InlineData("Z", 26)]
        [InlineData("AZ", 27)]
        [InlineData("SKY", 55)]
        public static void Puzzle042_GetScore_Returns_Correct_Result(string word, int expected)
        {
            // Act
            int actual = Puzzle042.GetScore(word);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 10)]
        [InlineData(5, 15)]
        [InlineData(6, 21)]
        [InlineData(7, 28)]
        [InlineData(8, 36)]
        [InlineData(9, 45)]
        [InlineData(10, 55)]
        public static void Puzzle042_TriangleNumber_Returns_Correct_Result(int n, int expected)
        {
            // Act
            int actual = Puzzle042.TriangleNumber(n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Puzzle042_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 162;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle042>(expected);
        }
    }
}
