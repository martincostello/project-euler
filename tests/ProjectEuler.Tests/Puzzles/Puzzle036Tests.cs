// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Xunit;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle036"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle036Tests
    {
        [Theory]
        [InlineData("585", true)]
        [InlineData("100000", false)]
        [InlineData("100001", true)]
        [InlineData("1000000", false)]
        [InlineData("1000001", true)]
        [InlineData("10000001", true)]
        [InlineData("100010001", true)]
        [InlineData("1001001001", true)]
        public static void Puzzle036_IsPalindromic_Returns_Correct_Value(string value, bool expected)
        {
            // Act
            bool actual = Puzzle036.IsPalindromic(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Puzzle036_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 872187;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle036>(expected);
        }
    }
}
