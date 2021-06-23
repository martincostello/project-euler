// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Xunit;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle008"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle008Tests
    {
        [Theory]
        [InlineData("4", 5832L)]
        [InlineData("13", 23514624000L)]
        public static void Puzzle008_Returns_Correct_Solution(string value, long expected)
        {
            // Arrange
            string[] args = new[] { value };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle008>(args, expected);
        }

        [Fact]
        public static void Puzzle008_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle008>(args);
        }

        [Fact]
        public static void Puzzle008_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "1" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle008>(args);
        }
    }
}
