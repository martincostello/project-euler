// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=52</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle052 : Puzzle
    {
        /// <inheritdoc />
        public override string Question => "What is the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits?";

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            for (int i = 1; i < int.MaxValue; i++)
            {
                var digits1 = Maths.Digits(i);
                var digits2 = Maths.Digits(i * 2);

                if (digits1.Count != digits2.Count)
                {
                    continue;
                }

                var digits3 = Maths.Digits(i * 3);

                if (digits2.Count != digits3.Count)
                {
                    continue;
                }

                var digits4 = Maths.Digits(i * 4);

                if (digits3.Count != digits4.Count)
                {
                    continue;
                }

                var digits5 = Maths.Digits(i * 5);

                if (digits4.Count != digits5.Count)
                {
                    continue;
                }

                var digits6 = Maths.Digits(i * 6);

                if (digits5.Count != digits6.Count)
                {
                    continue;
                }

                var values = new HashSet<int>(digits1);

                bool HasSameDigits(IReadOnlyList<int> digits)
                {
                    for (int j = 0; j < digits.Count; j++)
                    {
                        if (!values.Contains(digits[j]))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                if (HasSameDigits(digits2) &&
                    HasSameDigits(digits3) &&
                    HasSameDigits(digits4) &&
                    HasSameDigits(digits5) &&
                    HasSameDigits(digits6))
                {
                    Answer = i;
                    break;
                }
            }

            return 0;
        }
    }
}
