// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class containing helper methods. This class cannot be inherited.
    /// </summary>
    internal static class Helpers
    {
        /// <summary>
        /// Returns whether the specified collection is palindromic.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to test for being a palindrome.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="collection"/> is a palindrome; otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsPalindromic<T>(IReadOnlyList<T> collection)
        {
            IEqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < collection.Count / 2; i++)
            {
                if (!comparer.Equals(collection[i], collection[collection.Count - i - 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
