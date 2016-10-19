// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Puzzle033"/> class. This class cannot be inherited.
    /// </summary>
    public static class Puzzle033Tests
    {
        [Theory]
        [InlineData(9d, 9d, false)]
        [InlineData(30d, 50d, false)]
        [InlineData(16d, 64d, true)]
        [InlineData(19d, 95d, true)]
        [InlineData(26d, 65d, true)]
        [InlineData(49d, 98d, true)]
        public static void Puzzle033_IsCurious_Returns_Correct_Result(double numerator, double denominator, bool expected)
        {
            // Act
            bool actual = Puzzle033.IsCuriousFraction(numerator, denominator);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Puzzle033_Returns_Correct_Solution()
        {
            // Act and Assert
            Puzzles.AssertSolution<Puzzle033>(100);
        }
    }
}
