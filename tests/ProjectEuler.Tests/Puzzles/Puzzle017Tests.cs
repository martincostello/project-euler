// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle017"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle017Tests
    {
        [Theory]
        [InlineData(1, "one")]
        [InlineData(7, "seven")]
        [InlineData(22, "twenty-two")]
        [InlineData(76, "seventy-six")]
        [InlineData(101, "one hundred and one")]
        [InlineData(110, "one hundred and ten")]
        [InlineData(115, "one hundred and fifteen")]
        [InlineData(150, "one hundred and fifty")]
        [InlineData(342, "three hundred and forty-two")]
        [InlineData(392, "three hundred and ninety-two")]
        [InlineData(600, "six hundred")]
        [InlineData(999, "nine hundred and ninety-nine")]
        [InlineData(1000, "one thousand")]
        [InlineData(4672, "four thousand six hundred and seventy-two")]
        [InlineData(9999, "nine thousand nine hundred and ninety-nine")]
        public static void Puzzle017_ToEnglish_Returns_Correct_Value(int value, string expected)
        {
            // Act
            string actual = Puzzle017.ToEnglish(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1", 3)]
        [InlineData("5", 19)]
        [InlineData("1000", 21124)]
        public static void Puzzle017_Returns_Correct_Solution(string maximum, int expected)
        {
            // Arrange
            string[] args = new[] { maximum };

            // Act and Assert
            Puzzles.AssertSolution<Puzzle017>(args, expected);
        }

        [Fact]
        public static void Puzzle017_Returns_Minus_One_If_Maximum_Is_Invalid()
        {
            // Arrange
            string[] args = new[] { "a" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle017>(args);
        }

        [Fact]
        public static void Puzzle017_Returns_Minus_One_If_Maximum_Is_Too_Small()
        {
            // Arrange
            string[] args = new[] { "0" };

            // Act and Assert
            Puzzles.AssertInvalid<Puzzle017>(args);
        }
    }
}
