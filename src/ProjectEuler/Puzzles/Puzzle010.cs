// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=10</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle010 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "Find the sum of all the primes below the specified value.";

    /// <inheritdoc />
    protected override int MinimumArguments => 1;

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        if (!TryParseInt32(args[0], out int maximum) || maximum < 2)
        {
            Console.WriteLine("The specified number is invalid.");
            return -1;
        }

        Answer = Maths.Primes(maximum)
            .AsParallel()
            .Select((p) => (long)p)
            .Sum();

        return 0;
    }
}
