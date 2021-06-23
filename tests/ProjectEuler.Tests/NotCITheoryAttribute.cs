// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System;
using Xunit;

namespace MartinCostello.ProjectEuler
{
    /// <summary>
    /// Represents a theory that should not be run as part of the continuous integration. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class NotCITheoryAttribute : TheoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotCITheoryAttribute"/> class.
        /// </summary>
        public NotCITheoryAttribute()
        {
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("CI")))
            {
                Skip = "Too slow.";
            }
        }
    }
}
