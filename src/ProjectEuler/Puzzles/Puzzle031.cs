// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=31</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle031 : Puzzle
    {
        /// <summary>
        /// The coins, in pence, available in GBP. This field is read-only.
        /// </summary>
        private static readonly int[] Coins = new[] { 1, 2, 5, 10, 20, 50, 100, 200 };

        /// <inheritdoc />
        public override string Question => "How many different ways can the specified amount of money, in pence, be made using any number of coins?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int target) || target < 1)
            {
                Console.WriteLine("The specified total is invalid.");
                return -1;
            }

            // Array containing the number of ways there are to
            // make 1p up to the target using the avaiable coins.
            int[] ways = new int[target + 1];

            // There is one way to make 1p
            ways[0] = 1;

            // Loop through each value of coin
            for (int coin = 0; coin < Coins.Length; coin++)
            {
                int coinValue = Coins[coin];

                if (coinValue > target)
                {
                    break;
                }

                // For each value from the coin's value to the target
                // find how many ways there are to create that value.
                for (int j = coinValue; j <= target; j++)
                {
                    int valueRemaining = j - coinValue;
                    ways[j] += ways[valueRemaining];
                }
            }

            Answer = ways[target];

            return 0;
        }
    }
}
