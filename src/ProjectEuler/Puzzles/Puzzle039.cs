﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=39</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle039 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "For which value of p <= 1000, is the number of solutions for a right-angled triangle with perimeter p maximised?";

    /// <summary>
    /// Returns the solutions for a right-angled triangle with the specified perimeter.
    /// </summary>
    /// <param name="perimeter">The perimeter of the right-angled triangle.</param>
    /// <returns>
    /// An <see cref="ICollection{T}"/> containing the solution(s) to the triangle with the perimeter specified by <paramref name="perimeter"/>.
    /// </returns>
    internal static ICollection<string> Solve(int perimeter)
    {
        var solutions = new HashSet<string>(perimeter * perimeter);
        double perimeterDouble = perimeter;

        // https://devblogs.microsoft.com/dotnet/floating-point-parsing-and-formatting-improvements-in-net-core-3-0/
        const string Format = "G15";
        var formatProvider = CultureInfo.InvariantCulture;

        for (double a = 1; a < perimeter - 2; a++)
        {
            for (double b = 1; b < perimeter - a - 1; b++)
            {
                double tangent = a / b;
                double θ = Math.Atan(tangent);

                double c = a / Math.Sin(θ);

                if (Math.Abs(a + b + c - perimeterDouble) < double.Epsilon)
                {
                    string[] sides =
                    [
                        a.ToString(Format, formatProvider),
                        b.ToString(Format, formatProvider),
                        c.ToString(Format, formatProvider),
                    ];

                    string solution = '{' + string.Join(',', sides.Order()) + '}';

                    solutions.Add(solution);
                }
            }
        }

        return solutions;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        const int Limit = 1_000;

        var solutions = new Dictionary<int, int>(Limit);

        for (int p = 3; p <= Limit; p++)
        {
            solutions[p] = Solve(p).Count;
        }

        Answer = solutions
            .OrderBy((p) => p.Value)
            .Select((p) => p.Key)
            .Last();

        return 0;
    }
}
