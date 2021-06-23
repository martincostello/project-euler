// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Xunit;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle009"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle009Tests
    {
        [Fact]
        public static void Puzzle009_Returns_Correct_Solution()
        {
            // Arrange
            object expected = 31875000;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle009>(expected);
        }
    }
}
