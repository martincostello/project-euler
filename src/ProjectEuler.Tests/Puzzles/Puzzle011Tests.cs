// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle011"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle011Tests
    {
        [Fact]
        public static void Puzzle011_Returns_Correct_Solution()
        {
            // Arrange
            string[] args = new string[0];
            var target = new Puzzle011();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(0, actual);
            Assert.Equal(70600674, target.Answer);
        }
    }
}
