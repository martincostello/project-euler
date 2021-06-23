// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle014"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle014Tests
    {
        [Fact]
        public static void Puzzle014_Returns_Correct_Solution()
        {
            // Arrange
            object expected = 837799;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle014>(expected);
        }

        [Theory]
        [InlineData(-1L, 0)]
        [InlineData(0L, 0)]
        [InlineData(1L, 1)]
        [InlineData(2L, 2)]
        [InlineData(3L, 8)]
        [InlineData(4L, 3)]
        [InlineData(13L, 10)]
        public static void Puzzle014_GetCollatzSequenceLength_Returns_Correct_Value(long start, int expected)
        {
            // Act
            int actual = Puzzle014.GetCollatzSequenceLength(start);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
