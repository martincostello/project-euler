// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle024"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle024Tests
    {
        [NotCIFact]
        public static void Puzzle024_Returns_Correct_Solution()
        {
            // Arrange
            string expected = "2783915460";

            // Act and Assert
            Puzzles.AssertSolution<Puzzle024>(expected);
        }
    }
}
