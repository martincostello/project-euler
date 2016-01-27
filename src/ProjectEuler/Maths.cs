// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A class containing mathematics-related methods. This class cannot be inherited.
    /// </summary>
    internal static class Maths
    {
        /// <summary>
        /// A cache of values for which being prime has been computed. This field is read-only.
        /// </summary>
        private static readonly IDictionary<long, bool> _primes = new ConcurrentDictionary<long, bool>();

        /// <summary>
        /// Returns the sum of two numbers specified as strings and returns the result.
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <returns>
        /// A <see cref="string"/> containing the sum of <paramref name="x"/> and <paramref name="y"/>.
        /// </returns>
        internal static string Sum(string x, string y)
        {
            string longest = x.Length <= y.Length ? y : x;
            string shortest = x.Length <= y.Length ? x : y;

            var first = new Stack<int>(Digits(longest));
            var second = new Stack<int>();

            // Pad the second value with the shortest number to have a
            // stack of characters the same length as the longest one.
            for (int i = 0; i < longest.Length - shortest.Length; i++)
            {
                second.Push(0);
            }

            foreach (int i in Digits(shortest))
            {
                second.Push(i);
            }

            var result = new Stack<char>();

            int carry = 0;

            while (first.Count > 0)
            {
                int firstNumber = first.Pop();
                int secondNumber = second.Pop();

                // Add the numbers and include the tens carry over from the last iteration
                int sum = firstNumber + secondNumber + carry;

                // Carry over the tens
                carry = sum / 10;

                // Add the ones to the result
                result.Push((char)((sum % 10) + '0'));
            }

            // Add the digit for any left over carry value
            if (carry != 0)
            {
                result.Push((char)(carry + '0'));
            }

            return new string(result.ToArray());
        }

        /// <summary>
        /// Returns the digits of the specified value in base 10.
        /// </summary>
        /// <param name="value">The value to get the digits for.</param>
        /// <returns>
        /// The digits of <paramref name="value"/> in base 10.
        /// </returns>
        internal static int[] Digits(string value)
        {
            var digits = new List<int>();

            foreach (char ch in value.TrimStart('-'))
            {
                digits.Add(ch - '0');
            }

            return digits.ToArray();
        }

        /// <summary>
        /// Returns the digits of the specified value in base 10.
        /// </summary>
        /// <param name="value">The value to get the digits for.</param>
        /// <returns>
        /// The digits of <paramref name="value"/> in base 10.
        /// </returns>
        internal static int[] Digits(long value)
        {
            if (value < 0)
            {
                value = Math.Abs(value);
            }

            var digits = new List<int>();

            while (value > 9)
            {
                digits.Add((int)(value % 10));
                value /= 10;
            }

            digits.Add((int)value);

            if (digits.Count > 1)
            {
                digits.Reverse();
            }

            return digits.ToArray();
        }

        /// <summary>
        /// Returns the factorial (<c>value!</c>) of the specified value.
        /// </summary>
        /// <param name="value">The value to get the factorial for.</param>
        /// <returns>
        /// The factorial of <paramref name="value"/>.
        /// </returns>
        internal static int Factorial(int value)
        {
            if (value == 0)
            {
                return 1;
            }

            int result = value;

            for (int i = value - 1; i > 1; i--)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// Returns the 64-bit integer represented by the specified digits.
        /// </summary>
        /// <param name="collection">The digits of the number.</param>
        /// <returns>
        /// The <see cref="long"/> represented by the digits in <paramref name="collection"/>.
        /// </returns>
        internal static long FromDigits(IList<int> collection)
        {
            long result = 0;

            for (int j = 0; j < collection.Count - 1; j++)
            {
                result += collection[j] * (long)Math.Pow(10, collection.Count - j - 1);
            }

            result += collection[collection.Count - 1];

            return result;
        }

        /// <summary>
        /// Returns the factors of the specified number.
        /// </summary>
        /// <param name="value">The value to get the factors for.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> which enumerates the factors of <paramref name="value"/>.
        /// </returns>
        internal static IEnumerable<long> GetFactors(long value) => GetFactorsUnordered(value).OrderBy((p) => p);

        /// <summary>
        /// Returns the proper divisors of the specified number.
        /// </summary>
        /// <param name="value">The value to get the proper divisors for.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> which enumerates the proper divisors of <paramref name="value"/>.
        /// </returns>
        internal static IEnumerable<long> GetProperDivisors(long value) => GetFactors(value).TakeWhile((p) => p != value);

        /// <summary>
        /// Returns whether the specified number is an abundant number.
        /// </summary>
        /// <param name="value">The number to test for being an abundant number.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is an abundant number; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsAbundantNumber(long value) => GetProperDivisors(value).Sum() > value;

        /// <summary>
        /// Returns whether the specified number is a perfect number.
        /// </summary>
        /// <param name="value">The number to test for being a perfect number.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is a perfect number; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsPerfectNumber(long value) => GetProperDivisors(value).Sum() == value;

        /// <summary>
        /// Returns whether the specified value is a prime number.
        /// </summary>
        /// <param name="value">The value to test for being prime.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is a prime number; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsPrime(long value)
        {
            if (value < 2)
            {
                return false;
            }

            if (value == 2)
            {
                return true;
            }

            if (value % 2 == 0)
            {
                return false;
            }

            bool result;

            if (_primes.TryGetValue(value, out result))
            {
                return result;
            }

            long sqrt = (long)Math.Sqrt(value);

            result = true;

            for (long i = sqrt; i > 1; i--)
            {
                if (value % i == 0)
                {
                    result = false;
                    break;
                }
            }

            return _primes[value] = result;
        }

        /// <summary>
        /// Returns all the permutations of the specified collection of values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="collection">The collection to get the permutations of.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that returns the permutations of <paramref name="collection"/>.
        /// </returns>
        internal static IEnumerable<IEnumerable<T>> Permutations<T>(ICollection<T> collection) => Permutations(collection, collection.Count);

        /// <summary>
        /// Returns all the permutations of the specified collection of values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="collection">The collection to get the permutations of.</param>
        /// <param name="count">The number of items to calculate the permutations from.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that returns the permutations of <paramref name="collection"/>.
        /// </returns>
        internal static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> collection, int count)
        {
            if (count == 1)
            {
                return collection.Select((p) => new[] { p });
            }

            return Permutations(collection, count - 1)
                .SelectMany((p) => collection.Where((r) => !p.Contains(r)), (set, value) => set.Concat(new[] { value }));
        }

        /// <summary>
        /// Returns the product of two specified values.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>
        /// A <see cref="string"/> representing the product of <paramref name="a"/> and <paramref name="b"/>.
        /// </returns>
        internal static string Pow(string a, int b)
        {
            if (b == 0)
            {
                return "1";
            }

            string current = a;

            for (int n = 0; n < b - 1; n++)
            {
                current = Product(current, a);
            }

            return current;
        }

        /// <summary>
        /// Returns the product of two specified values.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>
        /// A <see cref="string"/> representing the product of <paramref name="a"/> and <paramref name="b"/>.
        /// </returns>
        internal static string Product(string a, string b)
        {
            if (string.Equals(a, "0", StringComparison.Ordinal) || string.Equals(b, "0", StringComparison.Ordinal))
            {
                return "0";
            }

            var valuesToSum = new List<string>();
            int[] digits = Digits(b);

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                string current = a;
                int times = digits[i] * (int)Math.Pow(10, digits.Length - i - 1);

                if (times > 0)
                {
                    for (int j = 1; j < times; j++)
                    {
                        current = Sum(current, a);
                    }

                    valuesToSum.Add(current);
                }
            }

            return valuesToSum.Aggregate((x, y) => Sum(x, y));
        }

        /// <summary>
        /// Returns the factors of the specified number.
        /// </summary>
        /// <param name="value">The value to get the factors for.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the factors of the specified number.
        /// </returns>
        /// <remarks>
        /// The values returned are unsorted.
        /// </remarks>
        internal static IEnumerable<long> GetFactorsUnordered(long value)
        {
            for (int i = 1; i * i <= value; i++)
            {
                if (value % i == 0)
                {
                    yield return i;

                    if (i * i != value)
                    {
                        yield return value / i;
                    }
                }
            }
        }
    }
}
