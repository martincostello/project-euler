// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Numerics;

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=48</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle048 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + N^N.";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int n) || n < 2)
        {
            Console.WriteLine("The specified number is invalid.");
            return -1;
        }

        var value = BigInteger.Zero;

        foreach (int exponent in Enumerable.Range(1, n))
        {
            value += BigInteger.Pow(exponent, exponent);
        }

        string result = value.ToString(CultureInfo.InvariantCulture);
        result = result.Substring(Math.Max(0, result.Length - 10), 10);

        Answer = result;

        return 0;
    }
}
