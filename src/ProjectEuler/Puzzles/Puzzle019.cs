// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using NodaTime;

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=19</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle019 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        var date = new LocalDate(1901, 1, 1);
        var max = date.PlusYears(100);

        int sundaysOnTheFirstOfTheMonth = 0;

        while (date < max)
        {
            if (date.DayOfWeek == IsoDayOfWeek.Sunday)
            {
                sundaysOnTheFirstOfTheMonth++;
            }

            date = date.PlusMonths(1);
        }

        Answer = sundaysOnTheFirstOfTheMonth;

        return 0;
    }
}
