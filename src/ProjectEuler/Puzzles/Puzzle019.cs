// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    using System;

    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=19</c>. This class cannot be inherited.
    /// </summary>
    internal sealed class Puzzle019 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            DateTime date = new DateTime(1901, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime max = date.AddYears(100);

            int sundaysOnTheFirstOfTheMonth = 0;

            while (date < max)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    sundaysOnTheFirstOfTheMonth++;
                }

                date = date.AddMonths(1);
            }

            Answer = sundaysOnTheFirstOfTheMonth;

            return 0;
        }
    }
}
