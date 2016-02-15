// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System.Linq;
    using System.Numerics;
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle025"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle025Tests
    {
        [Fact]
        public static void Puzzle025_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 4782;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle025>(expected);
        }

        [Fact]
        public static void Puzzle025_Fibonacci_Returns_Correct_Sequence()
        {
            // Arrange
            var expected = new BigInteger[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            // Act
            var actual = Puzzle025.Fibonacci()
                .Take(expected.Length)
                .ToArray();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
