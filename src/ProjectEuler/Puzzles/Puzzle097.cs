﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Numerics;

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=97</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle097 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "What are the last ten digits of 28433 * 2^7830457 + 1?";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        BigInteger value = (28433 * BigInteger.Pow(2, 7830457)) + 1;

        var digits = new List<int>(10);

        for (int i = 0; i < 10; i++)
        {
            value = BigInteger.DivRem(value, 10, out var rem);
            digits.Add((int)rem);
        }

        digits.Reverse();

        Answer = Maths.FromDigits(digits);

        return 0;
    }
}
