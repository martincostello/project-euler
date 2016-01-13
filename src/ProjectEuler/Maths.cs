// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A class containing mathematics-related methods. This class cannot be inherited.
    /// </summary>
    internal static class Maths
    {
        /// <summary>
        /// Adds the two numbers specified as strings and returns the result.
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <returns>
        /// A <see cref="string"/> containing the result of adding <paramref name="x"/> and <paramref name="y"/>.
        /// </returns>
        internal static string Add(string x, string y)
        {
            string longest = x.Length <= y.Length ? y : x;
            string shortest = x.Length <= y.Length ? x : y;

            Stack<char> first = new Stack<char>(longest);
            Stack<char> second = new Stack<char>();

            // Pad the second value with the shortest number to have a
            // stack of characters the same length as the longest one.
            for (int i = 0; i < longest.Length - shortest.Length; i++)
            {
                second.Push('0');
            }

            foreach (char ch in shortest)
            {
                second.Push(ch);
            }

            Stack<char> result = new Stack<char>();

            int carry = 0;

            while (first.Count > 0)
            {
                // Get the next numbers from the digits' next character
                int firstNumber = first.Pop() - '0';
                int secondNumber = second.Pop() - '0';

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
        /// Returns the factors of the specified number.
        /// </summary>
        /// <param name="value">The value to get the factors for.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> which enumerates the factors of <paramref name="value"/>.
        /// </returns>
        internal static IEnumerable<long> GetFactors(long value) => GetFactorsInternal(value).OrderBy((p) => p);

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
        internal static bool IsAbundantNumber(long value)
        {
            return GetProperDivisors(value).Sum() > value;
        }

        /// <summary>
        /// Returns whether the specified number is a perfect number.
        /// </summary>
        /// <param name="value">The number to test for being a perfect number.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is a perfect number; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsPerfectNumber(long value)
        {
            return GetProperDivisors(value).Sum() == value;
        }

        /// <summary>
        /// Returns whether the specified value is a prime number.
        /// </summary>
        /// <param name="value">The value to test for being prime.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is a prime number; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsPrime(long value)
        {
            if (value == 1)
            {
                return false;
            }

            long sqrt = (long)Math.Sqrt(value);

            for (long i = sqrt; i > 1; i--)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns all the permutations of the specified collection of values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="collection">The collection to get the permutations of.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that returns the permutations of <paramref name="collection"/>.
        /// </returns>
        internal static IEnumerable<IEnumerable<T>> Permutations<T>(ICollection<T> collection)
        {
            return Permutations(collection, collection.Count);
        }

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
        /// Returns the factors of the specified number.
        /// </summary>
        /// <param name="value">The value to get the factors for.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the factors of the specified number.
        /// </returns>
        /// <remarks>
        /// The values returned are unsorted.
        /// </remarks>
        private static IEnumerable<long> GetFactorsInternal(long value)
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
