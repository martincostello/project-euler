// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle050"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle050Tests
    {
        [Theory]
        [InlineData("6", 5)]
        [InlineData("100", 41)]
        [InlineData("1000000", 997651)]
        public static void Puzzle050_Returns_Correct_Solution(string maximum, int expected)
        {
            // Arrange
            string[] args = new[] { maximum };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle050>(args, expected);
        }

        [Fact]
        public static void Puzzle050_Returns_Minus_One_If_Maximum_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle050>(args);
        }

        [Fact]
        public static void Puzzle050_Returns_Minus_One_If_Maximum_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "2" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle050>(args);
        }
    }
}
