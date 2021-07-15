// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle052"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle052Tests
    {
        [Fact]
        public static void Puzzle052_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 142857;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle052>(expected);
        }
    }
}
