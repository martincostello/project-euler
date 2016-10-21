// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle043"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle043Tests
    {
        [Fact]
        public static void Puzzle043_Returns_Correct_Solution()
        {
            // Arrange
            long expected = 16695334890;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle043>(expected);
        }
    }
}
