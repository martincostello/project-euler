// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A class containing mathematics-related methods. This class cannot be inherited.
    /// </summary>
    internal static class Maths
    {
        /// <summary>
        /// Returns the factors of the specified number.
        /// </summary>
        /// <param name="value">The value to get the factors for.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the factors of the specified number.
        /// </returns>
        internal static IEnumerable<long> GetFactors(long value)
        {
            if (value > 1)
            {
                // 1 is a factor of positive numbers
                yield return 1;

                long half = value / 2;

                for (long i = 2; i <= half; i++)
                {
                    if (value % i == 0)
                    {
                        yield return i;
                    }
                }
            }

            // A number is always a factor of itself
            yield return value;
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
    }
}
