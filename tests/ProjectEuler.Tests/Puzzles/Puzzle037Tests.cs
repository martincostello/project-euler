// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle037"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle037Tests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        [InlineData(3797, true)]
        [InlineData(3798, false)]
        public static void Puzzle037_AllTruncatedValuesArePrime_Returns_Correct_Result(int value, bool expected)
        {
            // Act
            bool actual = Puzzle037.AllTruncatedValuesArePrime(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3797, true, 797)]
        [InlineData(797, true, 97)]
        [InlineData(97, true, 7)]
        [InlineData(3797, false, 379)]
        [InlineData(379, false, 37)]
        [InlineData(37, false, 3)]
        public static void Puzzle037_Truncate_Returns_Correct_Result(long value, bool removeLeft, long expected)
        {
            // Act
            long actual = Puzzle037.Truncate(value, removeLeft);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Puzzle037_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 748317;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle037>(expected);
        }
    }
}
