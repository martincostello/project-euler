// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle023"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle023Tests
    {
        [Fact]
        public static void Puzzle023_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 4179871;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle023>(expected);
        }
    }
}
