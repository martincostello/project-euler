// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System;
    using Puzzles;
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Program"/> class. This class cannot be inherited.
    /// </summary>
    public static class ProgramTests
    {
        /// <summary>
        /// Gets the test data for <see cref="Program_Returns_Zero_If_Input_Valid"/>.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Required for use by xunit.")]
        public static object[][] Args
        {
            get
            {
                return new[]
                {
                    new[] { new[] { "1", "10" } },
                    new[] { new[] { "13" } },
                };
            }
        }

        [Fact]
        public static void Program_SolvePuzzle_Returns_Zero_If_Input_Valid()
        {
            // Arrange
            Type type = typeof(Puzzle001);
            string[] args = new[] { "10" };

            // Act
            int actual = Program.SolvePuzzle(type, args);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public static void Program_SolvePuzzle_Returns_Minus_One_If_Input_Invalid()
        {
            // Arrange
            Type type = typeof(Puzzle001);
            string[] args = new string[0];

            // Act
            int actual = Program.SolvePuzzle(type, args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Theory]
        [MemberData(nameof(Args))]
        public static void Program_Returns_Zero_If_Input_Valid(string[] args)
        {
            // Act
            int actual = Program.Main(args);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public static void Program_Exits_If_Null_Arguments()
        {
            // Arrange
            string[] args = null;

            // Act
            int actual = Program.Main(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Program_Exits_If_No_Arguments()
        {
            // Arrange
            string[] args = new string[0];

            // Act
            int actual = Program.Main(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Program_Exits_If_Invalid_Day()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act
            int actual = Program.Main(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Program_Exits_If_Day_Too_Small()
        {
            // Arrange
            string[] args = new[] { "0" };

            // Act
            int actual = Program.Main(args);

            // Assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public static void Program_Exits_If_Day_Too_Large()
        {
            // Arrange
            string[] args = new[] { "999" };

            // Act
            int actual = Program.Main(args);

            // Assert
            Assert.Equal(-1, actual);
        }
    }
}
