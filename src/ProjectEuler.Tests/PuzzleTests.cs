// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System;
    using System.Linq;
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
            Puzzle target = new MyPuzzle(2);

            // Act
            int actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);

            // Arrange
            args = new string[0];
            target = new MyPuzzle(1);

            // Act
            actual = target.Solve(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Puzzles_Have_Questions()
        {
            // Arrange
            var puzzleType = typeof(IPuzzle);

            var puzzleTypes = puzzleType.Assembly
                .GetTypes()
                .Where((p) => !p.IsAbstract)
                .Where((p) => puzzleType.IsAssignableFrom(p))
                .ToList();

            Assert.NotEmpty(puzzleTypes);

            foreach (var type in puzzleTypes)
            {
                // Act
                var puzzle = Activator.CreateInstance(type) as IPuzzle;

                // Assert
                Assert.NotNull(puzzle);
                Assert.NotNull(puzzle.Question);
                Assert.NotEmpty(puzzle.Question);
            }
        }

        private sealed class MyPuzzle : Puzzle
        {
            /// <summary>
            /// The value to use ofr <see cref="MinimumArguments"/>.
            /// </summary>
            private readonly int _minimumArguments;

            /// <summary>
            /// Initializes a new instance of the <see cref="MyPuzzle"/> class.
            /// </summary>
            /// <param name="minimumArguments">The value to use for <see cref="MinimumArguments"/>.</param>
            internal MyPuzzle(int minimumArguments)
            {
                _minimumArguments = minimumArguments;
            }

            /// <inheritdoc />
            public override string Question => "What is the meaning of life, the universe and everything?";

            /// <inheritdoc />
            protected override int MinimumArguments => _minimumArguments;

            /// <inheritdoc />
            protected override int SolveCore(string[] args)
            {
                Answer = 42;
                return 0;
            }
        }
    }
}
