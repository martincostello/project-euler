// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Maths"/> class. This class cannot be inherited.
    /// </summary>
    public static class MathsTests
    {
        [Theory]
        [InlineData(1, new long[] { 1 })]
        [InlineData(2, new long[] { 1, 2 })]
        [InlineData(3, new long[] { 1, 3 })]
        [InlineData(4, new long[] { 1, 2, 4 })]
        [InlineData(5, new long[] { 1, 5 })]
        [InlineData(6, new long[] { 1, 2, 3, 6 })]
        [InlineData(10, new long[] { 1, 2, 5, 10 })]
        [InlineData(15, new long[] { 1, 3, 5, 15 })]
        [InlineData(21, new long[] { 1, 3, 7, 21 })]
        [InlineData(28, new long[] { 1, 2, 4, 7, 14, 28 })]
        public static void Maths_GetFactors_Returns_Correct_Values(long value, long[] expected)
        {
            // Act
            var actual = Maths.GetFactors(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        [InlineData(11, true)]
        [InlineData(12, false)]
        [InlineData(13, true)]
        [InlineData(14, false)]
        [InlineData(15, false)]
        [InlineData(16, false)]
        [InlineData(17, true)]
        [InlineData(18, false)]
        [InlineData(19, true)]
        [InlineData(20, false)]
        [InlineData(21, false)]
        [InlineData(22, false)]
        [InlineData(23, true)]
        [InlineData(24, false)]
        [InlineData(25, false)]
        [InlineData(26, false)]
        [InlineData(27, false)]
        [InlineData(28, false)]
        [InlineData(29, true)]
        [InlineData(30, false)]
        [InlineData(31, true)]
        [InlineData(37, true)]
        [InlineData(41, true)]
        [InlineData(43, true)]
        [InlineData(47, true)]
        [InlineData(53, true)]
        [InlineData(59, true)]
        [InlineData(61, true)]
        [InlineData(67, true)]
        [InlineData(71, true)]
        [InlineData(73, true)]
        [InlineData(79, true)]
        [InlineData(83, true)]
        [InlineData(89, true)]
        [InlineData(97, true)]
        public static void Maths_IsPrime_Returns_Correct_Value(long value, bool expected)
        {
            // Act
            var actual = Maths.IsPrime(value);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
