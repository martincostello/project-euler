﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle004"/> class.
    /// </summary>
    public static class Puzzle004Tests
    {
        [Theory]
        [InlineData("2", 9009)]
        [InlineData("3", 906609)]
        public static void Puzzle004_Returns_Correct_Solution(string digits, int expected)
        {
            // Arrange
            string[] args = new[] { digits };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle004>(args, expected);
        }

        [Fact]
        public static void Puzzle004_Returns_Minus_One_If_Maximum_Value_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle004>(args);
        }

        [Fact]
        public static void Puzzle004_Returns_Minus_One_If_Maximum_Value_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "1" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle004>(args);
        }
    }
}
