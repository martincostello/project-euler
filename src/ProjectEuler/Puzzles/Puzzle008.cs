﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System;
using System.Globalization;
using System.Numerics;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=8</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle008 : Puzzle
    {
        /// <summary>
        /// The one thousand digit number to use.
        /// </summary>
        private static readonly BigInteger OneThousandDigitNumber = BigInteger.Parse("7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450", CultureInfo.InvariantCulture);

        /// <inheritdoc />
        public override string Question => "Find the number of adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?";

        /// <inheritdoc />
        protected override int MinimumArguments => 1;

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            if (!TryParseInt32(args[0], out int digitCount) || digitCount < 2)
            {
                Console.WriteLine("The specified number is invalid.");
                return -1;
            }

            int limit = 1000 - digitCount;

            var products = new long[limit];
            var digits = Maths.Digits(OneThousandDigitNumber);

            for (int i = 0; i < limit; i++)
            {
                long product = digits[i];

                for (int j = 1; j < digitCount; j++)
                {
                    product *= digits[i + j];
                }

                products[i] = product;
            }

            Array.Sort(products);

            Answer = products[^1];

            return 0;
        }
    }
}
