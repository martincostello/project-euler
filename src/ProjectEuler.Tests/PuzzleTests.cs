// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle"/> class. This class cannot be inherited.
    /// </summary>
    public static class PuzzleTests
    {
        [Fact]
        public static void Puzzle_Returns_Minus_One_If_Too_Few_Arguments()
        {
            // Arrange
            string[] args = new[] { "1" };

            Puzzle target = new MyPuzzle();

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        private sealed class MyPuzzle : Puzzle
        {
            /// <inheritdoc />
            public override string Question => "What is the meaning of life, the universe and everything?";

            /// <inheritdoc />
            protected override int MinimumArguments => 2;

            /// <inheritdoc />
            protected override int SolveCore(string[] args)
            {
                Answer = 42;
                return 0;
            }
        }
    }
}
