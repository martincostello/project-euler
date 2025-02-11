// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Collections.Concurrent;
using System.Numerics;

namespace MartinCostello.ProjectEuler;

/// <summary>
/// A class containing mathematics-related methods. This class cannot be inherited.
/// </summary>
internal static class Maths
{
    /// <summary>
    /// An array containing the digits for base10. This field is read-only.
    /// </summary>
    private static readonly int[] Base10Digits = [.. Enumerable.Range(0, 10)];

    /// <summary>
    /// A cache of values for which being prime has been computed. This field is read-only.
    /// </summary>
    private static readonly ConcurrentDictionary<long, bool> _primes = new();

    /// <summary>
    /// Returns the binomial coefficient for the specified values.
    /// </summary>
    /// <param name="n">The number of values.</param>
    /// <param name="k">The number of values to select.</param>
    /// <returns>
    /// The value of the binomial coefficient for <paramref name="n"/> and <paramref name="k"/>.
    /// </returns>
    internal static long Binomial(int n, int k)
    {
        double result = 1;

        for (int i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }

        return (long)result;
    }

    /// <summary>
    /// Returns the cumulative sum for the specified values.
    /// </summary>
    /// <param name="collection">The values to compute the cumulative sum for.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the cumulative sum for <paramref name="collection"/>.
    /// </returns>
    internal static IEnumerable<int> CumulativeSum(IEnumerable<int> collection)
    {
        int sum = 0;

        foreach (int value in collection)
        {
            sum += value;
            yield return sum;
        }
    }

    /// <summary>
    /// Returns the digits of the specified value in base 10.
    /// </summary>
    /// <param name="value">The value to get the digits for.</param>
    /// <returns>
    /// The digits of <paramref name="value"/> in base 10.
    /// </returns>
    internal static IList<int> Digits(BigInteger value)
    {
        if (value == BigInteger.Zero)
        {
            return [0];
        }

        if (value < BigInteger.Zero)
        {
            value = BigInteger.Negate(value);
        }

        var digits = new List<int>();

        while (value > 0)
        {
            var div = BigInteger.DivRem(value, 10, out var rem);

            digits.Add((int)rem);
            value = div;
        }

        digits.Reverse();

        return digits;
    }

    /// <summary>
    /// Returns the digits of the specified value in base 10.
    /// </summary>
    /// <param name="value">The value to get the digits for.</param>
    /// <returns>
    /// The digits of <paramref name="value"/> in base 10.
    /// </returns>
    internal static IReadOnlyList<int> Digits(long value)
    {
        if (value == 0)
        {
            return [0];
        }

        value = Math.Abs(value);

        var digits = new List<int>();

        while (value > 0)
        {
            (long div, long rem) = Math.DivRem(value, 10);

            digits.Add((int)rem);
            value = div;
        }

        digits.Reverse();

        return digits;
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
        double result = 0;

        for (int j = 0; j < collection.Count - 1; j++)
        {
            result += collection[j] * Math.Pow(10, collection.Count - j - 1);
        }

        result += collection[collection.Count - 1];

        return (long)result;
    }

    /// <summary>
    /// Returns the factors of the specified number.
    /// </summary>
    /// <param name="value">The value to get the factors for.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> which enumerates the factors of <paramref name="value"/>.
    /// </returns>
    internal static IEnumerable<long> GetFactors(long value) => GetFactorsUnordered(value).Order();

    /// <summary>
    /// Returns the proper divisors of the specified number.
    /// </summary>
    /// <param name="value">The value to get the proper divisors for.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> which enumerates the proper divisors of <paramref name="value"/>.
    /// </returns>
    internal static IEnumerable<long> GetProperDivisors(long value) => GetFactors(value).TakeWhile((p) => p != value);

    /// <summary>
    /// Returns the hexagonal number for the specified value.
    /// </summary>
    /// <param name="n">The value to calculate the hexagonal number for.</param>
    /// <returns>
    /// The hexagonal number of <paramref name="n"/>.
    /// </returns>
    internal static long Hexagonal(long n) => n * ((2 * n) - 1);

    /// <summary>
    /// Returns whether the specified number is an abundant number.
    /// </summary>
    /// <param name="value">The number to test for being an abundant number.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> is an abundant number; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsAbundantNumber(long value)
    {
        long sum = 0;

        using var enumerator = GetProperDivisors(value).GetEnumerator();

        while (enumerator.MoveNext() && sum <= value)
        {
            sum += enumerator.Current;
        }

        return sum > value;
    }

    /// <summary>
    /// Returns whether the specified number is an hexagonal number.
    /// </summary>
    /// <param name="x">The value to test for being hexagonal.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="x"/> is an hexagonal number; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsHexagonal(long x) => Math.Abs(Math.IEEERemainder(1 + Math.Sqrt(1 + (8d * x)), 4)) < double.Epsilon;

    /// <summary>
    /// Returns whether the specified value is pandigital.
    /// </summary>
    /// <param name="value">The value to test for being pandigital.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> is pandigital; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsPandigital(long value)
    {
        IReadOnlyList<int> digits = Digits(value);
        int[] distinctDigits = [.. digits.Distinct()];

        if (digits.Count != distinctDigits.Length)
        {
            return false;
        }

        IEnumerable<int> expectedDigits = Base10Digits
            .Skip(1)
            .Take(digits.Count);

        return !distinctDigits.Except(expectedDigits).Any();
    }

    /// <summary>
    /// Returns whether the specified number is a pentagonal number.
    /// </summary>
    /// <param name="x">The value to test for being pentagonal.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="x"/> is a pentagonal number; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsPentagonal(long x) => Math.Abs(Math.IEEERemainder(Math.Sqrt((24d * x) + 1) + 1, 6)) < double.Epsilon;

    /// <summary>
    /// Returns whether the specified number is a triangular number.
    /// </summary>
    /// <param name="x">The value to test for being triangular.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="x"/> is a triangular number; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsTriangular(long x) => IsPerfectSquare((8 * x) + 1);

    /// <summary>
    /// Returns whether the specified number is a perfect number.
    /// </summary>
    /// <param name="value">The number to test for being a perfect number.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> is a perfect number; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsPerfectNumber(long value) => GetProperDivisors(value).Sum() == value;

    /// <summary>
    /// Returns whether the specified number is a perfect square.
    /// </summary>
    /// <param name="value">The number to test for being a perfect square.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> is a perfect square; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsPerfectSquare(long value) => GetProperDivisors(value).Any((p) => p * p == value);

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

        if (value < 4)
        {
            return true;
        }

        if (value % 2 == 0 || value % 3 == 0)
        {
            return false;
        }

        if (_primes.TryGetValue(value, out bool result))
        {
            return result;
        }

        result = true;

        long i = 5;

        while (i * i <= value)
        {
            if (value % i == 0 || value % (i + 2) == 0)
            {
                result = false;
                break;
            }

            i += 6;
        }

        return _primes[value] = result;
    }

    /// <summary>
    /// Returns the pentagonal number for the specified value.
    /// </summary>
    /// <param name="n">The value to calculate the pentagonal number for.</param>
    /// <returns>
    /// The pentagonal number of <paramref name="n"/>.
    /// </returns>
    internal static long Pentagonal(long n) => n * ((3 * n) - 1) / 2;

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
            .SelectMany((p) => collection.Where((r) => !p.Contains(r)), (set, value) => set.Append(value));
    }

    /// <summary>
    /// Enumerates the prime numbers below the specified value.
    /// </summary>
    /// <param name="maximum">The maximum prime number.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that returns all the prime numbers below <paramref name="maximum"/>.
    /// </returns>
    internal static IEnumerable<int> Primes(int maximum)
    {
        // Based on https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes#Algorithm_and_variants
        if (maximum < 3)
        {
            yield break;
        }

        // Array of prime candidates. A value of false at an
        // index means that the value of the index is prime.
        bool[] primeCandidates = new bool[maximum];

        // 0 and 1 are not prime
        primeCandidates[0] = true;
        primeCandidates[1] = true;

        int root = (int)Math.Sqrt(maximum);

        for (int i = 2; i <= root; i++)
        {
            if (!primeCandidates[i])
            {
                // Mark all values i^2 * ij up to the maximum as not prime
                for (int j = 0; ; j++)
                {
                    int k = (i * i) + (i * j);

                    if (k >= maximum)
                    {
                        break;
                    }

                    primeCandidates[k] = true;
                }
            }
        }

        for (int i = 2; i < primeCandidates.Length; i++)
        {
            if (!primeCandidates[i])
            {
                yield return i;
            }
        }

        // Only odd values are prime (except 2)
        for (int i = 3; i < primeCandidates.Length; i += 2)
        {
            if (!primeCandidates[i])
            {
                _primes[i] = true;
            }
        }
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
            (long div, long rem) = Math.DivRem(value, i);

            if (rem == 0)
            {
                yield return i;

                if (i * i != value)
                {
                    yield return div;
                }
            }
        }
    }

    /// <summary>
    /// Returns the triangular number for the specified value.
    /// </summary>
    /// <param name="n">The value to calculate the triangular number for.</param>
    /// <returns>
    /// The triangular number of <paramref name="n"/>.
    /// </returns>
    internal static long Triangular(long n) => n * (n + 1) / 2;
}
