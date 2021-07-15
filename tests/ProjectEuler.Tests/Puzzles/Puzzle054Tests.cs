// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing tests for the <see cref="Puzzle54"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle054Tests
    {
        [Theory]
        [InlineData("5H 5C 6S 7S KD 2C 3S 8S 8D TD", false)]
        [InlineData("5D 8C 9S JS AC 2C 5C 7D 8S QH", true)]
        [InlineData("2D 9C AS AH AC 3D 6D 7D TD QD", false)]
        [InlineData("4D 6S 9H QH QC 3D 6D 7H QD QS", true)]
        [InlineData("2H 2D 4C 4D 4S 3C 3D 3S 9S 9D", true)]
        public static void IsFirstPlayerTheWinner_Returns_Correct_Value(string hand, bool expected)
        {
            // Act
            bool actual = Puzzle054.IsFirstPlayerTheWinner(hand);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Puzzle054_Returns_Correct_Solution()
        {
            // Arrange
            int expected = 376;

            // Act and Assert
            Puzzles.AssertSolution<Puzzle054>(expected);
        }
    }
}
