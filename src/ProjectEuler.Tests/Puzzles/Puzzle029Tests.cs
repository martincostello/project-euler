// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle029"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle029Tests
    {
        [Theory]
        [InlineData(5, new[] { "4", "8", "9", "16", "25", "27", "32", "64", "81", "125", "243", "256", "625", "1024", "3125" })]
        public static void Puzzle029_GeneratePowerSequence_Returns_Correct_Sequence(int maximum, IEnumerable<string> expected)
        {
            // Act
            IEnumerable<string> actual = Puzzle029.GeneratePowerSequence(maximum)
                .Distinct()
                .OrderBy((p) => p.Length)
                .ThenBy((p) => p);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("5", 15)]
        public static void Puzzle029_Returns_Correct_Solution(string maximum, int expected)
        {
            // Arrange
            string[] args = new[] { maximum };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle029>(args, expected);
        }

        [NotCITheory]
        [InlineData("100", 9183)]
        public static void Puzzle029_Returns_Correct_Solution_Slow(string maximum, int expected)
        {
            // Arrange
            string[] args = new[] { maximum };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle029>(args, expected);
        }

        [Fact]
        public static void Puzzle029_Returns_Minus_One_If_Number_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle029>(args);
        }
    }
}
