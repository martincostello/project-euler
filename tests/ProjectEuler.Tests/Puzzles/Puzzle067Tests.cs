// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Xunit;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle067"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle067Tests
    {
        [Fact]
        public static void Puzzle067_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 7273;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle067>(expected);
        }
    }
}
