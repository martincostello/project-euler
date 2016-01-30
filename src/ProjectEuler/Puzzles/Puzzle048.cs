// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=48</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle048 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + N^N.";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            int n;

            if (!TryParseInt32(args[0], out n) || n < 2)
            {
                Console.Error.WriteLine("The specified number is invalid.");
                return -1;
            }

            Answer = Enumerable.Range(1, n)
                .Select((p) => Maths.Pow(p.ToString(CultureInfo.InvariantCulture), p))
                .Aggregate((x, y) => Maths.Sum(x, y));

            return 0;
        }
    }
}
