// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Xunit;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle019"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle019Tests
    {
        [Fact]
        public static void Puzzle019_Returns_Correct_Solution()
        {
            // Arrange
            object expected = 171;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle019>(expected);
        }
    }
}
