// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle044"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle044Tests
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(12, true)]
        [InlineData(22, true)]
        [InlineData(35, true)]
        [InlineData(51, true)]
        [InlineData(70, true)]
        [InlineData(92, true)]
        [InlineData(117, true)]
        [InlineData(145, true)]
        public static void Puzzle044_IsPentagonal_Returns_Correct_Value(int x, bool expected)
        {
            // Act
            bool actual = Puzzle044.IsPentagonal(x);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 5)]
        [InlineData(3, 12)]
        [InlineData(4, 22)]
        [InlineData(5, 35)]
        [InlineData(6, 51)]
        [InlineData(7, 70)]
        [InlineData(8, 92)]
        [InlineData(9, 117)]
        [InlineData(10, 145)]
        public static void Puzzle044_Pentagonal_Returns_Correct_Value(int n, int expected)
        {
            // Act
            int actual = Puzzle044.Pentagonal(n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Puzzle044_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 5482660;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle044>(expected);
        }
    }
}
