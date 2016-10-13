// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using Xunit;

    /// <summary>
    /// A class containing tests for the <see cref="Maths"/> class. This class cannot be inherited.
    /// </summary>
    public static class MathsTests
    {
        [Theory]
        [InlineData("-11", new[] { 1, 1 })]
        [InlineData("-10", new[] { 1, 0 })]
        [InlineData("-9", new[] { 9 })]
        [InlineData("-1", new[] { 1 })]
        [InlineData("0", new[] { 0 })]
        [InlineData("1", new[] { 1 })]
        [InlineData("2", new[] { 2 })]
        [InlineData("9", new[] { 9 })]
        [InlineData("10", new[] { 1, 0 })]
        [InlineData("99", new[] { 9, 9 })]
        [InlineData("100", new[] { 1, 0, 0 })]
        [InlineData("101", new[] { 1, 0, 1 })]
        [InlineData("999", new[] { 9, 9, 9 })]
        [InlineData("1000", new[] { 1, 0, 0, 0 })]
        [InlineData("1001", new[] { 1, 0, 0, 1 })]
        [InlineData("1002", new[] { 1, 0, 0, 2 })]
        public static void Maths_Digits_Returns_Correct_Value(string value, IEnumerable<int> expected)
        {
            // Arrange
            BigInteger parsed = BigInteger.Parse(value);

            // Act
            var actual = Maths.Digits(parsed);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-11, new[] { 1, 1 })]
        [InlineData(-10, new[] { 1, 0 })]
        [InlineData(-9, new[] { 9 })]
        [InlineData(-1, new[] { 1 })]
        [InlineData(0, new[] { 0 })]
        [InlineData(1, new[] { 1 })]
        [InlineData(2, new[] { 2 })]
        [InlineData(9, new[] { 9 })]
        [InlineData(10, new[] { 1, 0 })]
        [InlineData(99, new[] { 9, 9 })]
        [InlineData(100, new[] { 1, 0, 0 })]
        [InlineData(101, new[] { 1, 0, 1 })]
        [InlineData(999, new[] { 9, 9, 9 })]
        [InlineData(1000, new[] { 1, 0, 0, 0 })]
        [InlineData(1001, new[] { 1, 0, 0, 1 })]
        [InlineData(1002, new[] { 1, 0, 0, 2 })]
        public static void Maths_Digits_Returns_Correct_Value(long value, IEnumerable<int> expected)
        {
            // Act
            var actual = Maths.Digits(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        [InlineData(7, 5040)]
        [InlineData(8, 40320)]
        [InlineData(9, 362880)]
        [InlineData(10, 3628800)]
        public static void Maths_Factorial_Returns_Correct_Value(int value, int expected)
        {
            // Act
            int actual = Maths.Factorial(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0)]
        [InlineData(new[] { 1 }, 1)]
        [InlineData(new[] { 2 }, 2)]
        [InlineData(new[] { 9 }, 9)]
        [InlineData(new[] { 1, 0 }, 10)]
        [InlineData(new[] { 9, 9 }, 99)]
        [InlineData(new[] { 1, 0, 0 }, 100)]
        [InlineData(new[] { 1, 0, 1 }, 101)]
        [InlineData(new[] { 9, 9, 9 }, 999)]
        [InlineData(new[] { 1, 0, 0, 0 }, 1000)]
        [InlineData(new[] { 1, 0, 0, 1 }, 1001)]
        [InlineData(new[] { 1, 0, 0, 2 }, 1002)]
        public static void Maths_FromDigits_Returns_Correct_Value(IList<int> collection, int expected)
        {
            // Act
            var actual = Maths.FromDigits(collection);

            // Assert
            Assert.Equal(expected, actual);
        }

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
        [InlineData(2, new long[] { 1 })]
        [InlineData(3, new long[] { 1 })]
        [InlineData(4, new long[] { 1, 2 })]
        [InlineData(5, new long[] { 1 })]
        [InlineData(6, new long[] { 1, 2, 3 })]
        [InlineData(10, new long[] { 1, 2, 5 })]
        [InlineData(12, new long[] { 1, 2, 3, 4, 6 })]
        [InlineData(15, new long[] { 1, 3, 5 })]
        [InlineData(21, new long[] { 1, 3, 7 })]
        [InlineData(28, new long[] { 1, 2, 4, 7, 14 })]
        public static void Maths_GetProperDivisors_Returns_Correct_Values(long value, long[] expected)
        {
            // Act
            var actual = Maths.GetProperDivisors(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2, false)]
        [InlineData(-1, false)]
        [InlineData(0, false)]
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

        [Theory]
        [InlineData(12, true)]
        public static void Maths_IsAbundantNumber_Returns_Correct_Value(long value, bool expected)
        {
            // Act
            bool actual = Maths.IsAbundantNumber(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, false)]
        [InlineData(28, true)]
        public static void Maths_IsPerfectNumber_Returns_Correct_Value(long value, bool expected)
        {
            // Act
            bool actual = Maths.IsPerfectNumber(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void Maths_Permutations_Returns_Correct_Value_2()
        {
            // Arrange
            var collection = new[] { "a", "b" };

            // Act
            var actual = Maths.Permutations(collection)
                .Select((p) => p.ToArray())
                .ToArray();

            // Assert
            Assert.Equal(2, actual.Length);
            Assert.Equal(new[] { "a", "b" }, actual[0]);
            Assert.Equal(new[] { "b", "a" }, actual[1]);

            collection = new[] { "b", "a" };

            // Act
            actual = Maths.Permutations(collection)
                .Select((p) => p.ToArray())
                .ToArray();

            // Assert
            Assert.Equal(2, actual.Length);
            Assert.Equal(new[] { "b", "a" }, actual[0]);
            Assert.Equal(new[] { "a", "b" }, actual[1]);
        }

        [Fact]
        public static void Maths_Permutations_Returns_Correct_Value_3()
        {
            // Arrange
            var collection = new[] { "a", "b", "c" };

            // Act
            var actual = Maths.Permutations(collection)
                .Select((p) => p.ToArray())
                .ToArray();

            // Assert
            Assert.Equal(6, actual.Length);
            Assert.Equal(new[] { "a", "b", "c" }, actual[0]);
            Assert.Equal(new[] { "a", "c", "b" }, actual[1]);
            Assert.Equal(new[] { "b", "a", "c" }, actual[2]);
            Assert.Equal(new[] { "b", "c", "a" }, actual[3]);
            Assert.Equal(new[] { "c", "a", "b" }, actual[4]);
            Assert.Equal(new[] { "c", "b", "a" }, actual[5]);
        }

        [Theory]
        [InlineData(-2, new int[0])]
        [InlineData(-1, new int[0])]
        [InlineData(0, new int[0])]
        [InlineData(1, new int[0])]
        [InlineData(2, new int[0])]
        [InlineData(3, new[] { 2 })]
        [InlineData(4, new[] { 2, 3 })]
        [InlineData(5, new[] { 2, 3 })]
        [InlineData(6, new[] { 2, 3, 5 })]
        [InlineData(7, new[] { 2, 3, 5 })]
        [InlineData(8, new[] { 2, 3, 5, 7 })]
        [InlineData(9, new[] { 2, 3, 5, 7 })]
        [InlineData(10, new[] { 2, 3, 5, 7 })]
        [InlineData(11, new[] { 2, 3, 5, 7 })]
        [InlineData(12, new[] { 2, 3, 5, 7, 11 })]
        [InlineData(13, new[] { 2, 3, 5, 7, 11 })]
        [InlineData(14, new[] { 2, 3, 5, 7, 11, 13 })]
        [InlineData(15, new[] { 2, 3, 5, 7, 11, 13 })]
        [InlineData(16, new[] { 2, 3, 5, 7, 11, 13 })]
        [InlineData(17, new[] { 2, 3, 5, 7, 11, 13 })]
        [InlineData(18, new[] { 2, 3, 5, 7, 11, 13, 17 })]
        [InlineData(19, new[] { 2, 3, 5, 7, 11, 13, 17 })]
        [InlineData(20, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        [InlineData(21, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        [InlineData(22, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        [InlineData(23, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        [InlineData(24, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
        [InlineData(25, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
        [InlineData(26, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
        [InlineData(27, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
        [InlineData(28, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
        [InlineData(29, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
        [InlineData(30, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
        [InlineData(31, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
        [InlineData(37, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 })]
        [InlineData(41, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 })]
        [InlineData(43, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 })]
        [InlineData(47, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43 })]
        public static void Maths_Primes_Returns_Correct_Sequence(int maximum, IEnumerable<int> expected)
        {
            // Act
            IEnumerable<int> actual = Maths.Primes(maximum);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
