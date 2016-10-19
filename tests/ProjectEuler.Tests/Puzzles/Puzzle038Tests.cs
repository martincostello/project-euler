// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle038"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle038Tests
    {
        [Theory]
        [InlineData(192, 3, "192384576")]
        [InlineData(9, 5, "918273645")]
        public static void Puzzle038_Pandigital_Returns_Correct_Result(int value, int n, string expected)
        {
            // Act
            string actual = Puzzle038.Pandigital(value, n);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Puzzle038_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 932718654;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle038>(expected);
        }
    }
}
