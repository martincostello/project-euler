// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle018"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle018Tests
    {
        [Fact]
        public static void Puzzle018_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 1074;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle018>(expected);
        }
    }
}
