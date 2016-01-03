// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle003"/> class.
    /// </summary>
    public static class Puzzle003Tests
    {
        [Theory]
        [InlineData("13195", 29)]
        [InlineData("600851475143", 6857)]
        public static void Puzzle003_Returns_Correct_Solution(string value, long expected)
        {
            // Arrange
            string[] args = new[] { value };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle003>(args, expected);
        }

        [Fact]
        public static void Puzzle003_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle003>(args);
        }

        [Fact]
        public static void Puzzle003_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "0" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle003>(args);
        }
    }
}
