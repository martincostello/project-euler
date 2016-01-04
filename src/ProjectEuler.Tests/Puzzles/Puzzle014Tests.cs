// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

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

        [Fact]
        public static void Puzzle_014_GetCollatzSequence_Returns_Correct_Sequence()
        {
            // Arrange
            long start = 13;
            var expected = new long[] { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };

            // Act
            var actual = Puzzle014.GetCollatzSequence(start);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
