// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Collections.Generic;
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle039"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle039Tests
    {
        [Theory]
        [InlineData(-1, new string[] { })]
        [InlineData(0, new string[] { })]
        [InlineData(1, new string[] { })]
        [InlineData(12, new string[] { "{3,4,5}" })]
        [InlineData(120, new string[] { "{20,48,52}", "{24,45,51}", "{30,40,50}" })]
        public static void Puzzle039_Solve_Returns_Correct_Result(int p, string[] expected)
        {
            // Act
            ICollection<string> actual = Puzzle039.Solve(p);

            // Assert
            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public static void Puzzle039_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 840;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle039>(expected);
        }
    }
}
