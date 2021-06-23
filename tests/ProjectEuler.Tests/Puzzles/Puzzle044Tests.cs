// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Xunit;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle044"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle044Tests
    {
        [Fact]
        public static void Puzzle044_Returns_Correct_Solution()
        {
            // Arrange
            long expected = 5482660;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle044>(expected);
        }
    }
}
