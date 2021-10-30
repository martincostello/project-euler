﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=30</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle030 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "Find the sum of all the numbers that can be written as the sum of their digits raised to the specified ordinal power.";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <summary>
    /// Returns whether the specified value can be expressed as the
    /// sum of the digits of the value raised to the specified power.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <param name="power">The power to raise the digits of the value to.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> can be expressed
    /// as the sum of its digits raised to the power specified by
    /// <paramref name="power"/>; otherwise <see langword="false"/>.
    /// </returns>
    internal static bool IsSumOfDigitPowers(int value, int power)
    {
        IReadOnlyList<int> digits = Maths.Digits(value);

        double sum = 0;

        foreach (int digit in digits)
        {
            if (sum > value)
            {
                return false;
            }

            sum += Math.Pow(digit, power);
        }

        return (int)sum == value;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int power) || power < 0)
        {
            Console.WriteLine("The specified number is invalid.");
            return -1;
        }

        int sum;
        int upperBound;
        int nineToThePower = (int)Math.Pow(9, power);

        for (int digitCount = 2; ; digitCount++)
        {
            sum = digitCount * nineToThePower;
            IReadOnlyList<int> digitsOfSum = Maths.Digits(sum);

            if (digitsOfSum.Count <= digitCount)
            {
                upperBound = sum;
                break;
            }
        }

        sum = 0;

        for (int n = 2; n < upperBound; n++)
        {
            if (IsSumOfDigitPowers(n, power))
            {
                sum += n;
            }
        }

        Answer = sum;

        return 0;
    }
}
