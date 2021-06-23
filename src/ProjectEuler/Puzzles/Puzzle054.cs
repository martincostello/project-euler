// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.IO;

namespace MartinCostello.ProjectEuler.Puzzles
{
    /// <summary>
    /// A class representing the solution to <c>https://projecteuler.net/problem=54</c>. This class cannot be inherited.
    /// </summary>
    public sealed class Puzzle054 : Puzzle
    {
        private static readonly char[] Suits = { 'C', 'D', 'H', 'S' };
        private static readonly char[] Values = { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

        private delegate bool IsHandPredicate(string[] cards, out char highCard);

        /// <inheritdoc />
        public override string Question => "How many hands does Player 1 win?";

        internal static bool IsFirstPlayerTheWinner(string hand)
        {
            string[] cards = hand.Split(' ');

            string[] player1 = cards[..5];
            string[] player2 = cards[5..];

            player1 = player1.OrderBy((p) => GetCardValue(p)).ToArray();
            player2 = player2.OrderBy((p) => GetCardValue(p)).ToArray();

            var predicates = new IsHandPredicate[]
            {
                IsRoyalFlush,
                IsStraightFlush,
                IsFourOfAKind,
                IsFullHouse,
                IsFlush,
                IsStraight,
                IsThreeOfAKind,
                IsTwoPair,
                IsPair,
            };

            foreach (var predicate in predicates)
            {
                bool player1HasHand = predicate(player1, out char highCard1);
                bool player2HasHand = predicate(player2, out char highCard2);

                if (player1HasHand && player2HasHand)
                {
                    return DoesPlayer1HaveTheHighestCard(highCard1, highCard2);
                }
                else if (player1HasHand ^ player2HasHand)
                {
                    return player1HasHand;
                }
            }

            bool DoesPlayer1HaveTheHighestCard(char highCard1, char highCard2)
            {
                int card1Value = GetCardValue(highCard1);
                int card2Value = GetCardValue(highCard2);

                if (card1Value == card2Value)
                {
                    var otherCards1 = player1.Where((p) => p[0] != highCard1).ToArray();
                    var otherCards2 = player2.Where((p) => p[0] != highCard2).ToArray();

                    return GetCardValue(otherCards1[^1]) > GetCardValue(otherCards2[^1]);
                }
                else
                {
                    return card1Value > card2Value;
                }
            }

            int highestCard1 = player1.Max(GetCardValue);
            int highestCard2 = player2.Max(GetCardValue);

            return highestCard1 > highestCard2;
        }

        /// <inheritdoc />
        protected override int SolveCore(string[] args)
        {
            var hands = ReadHands();

            int winsForPlayer1 = 0;

            foreach (string hand in hands)
            {
                if (IsFirstPlayerTheWinner(hand))
                {
                    winsForPlayer1++;
                }
            }

            Answer = winsForPlayer1;

            return 0;
        }

        private static bool IsSuit(string card, char suit) => card[1] == suit;

        private static bool IsSameSuit(string[] hand)
        {
            foreach (char suit in Suits)
            {
                if (hand.All((p) => IsSuit(p, suit)))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValue(string card, char value) => card[0] == value;

        private static bool IsRoyalFlush(string[] hand, out char highCard)
        {
            highCard = default;

            if (!IsSameSuit(hand))
            {
                return false;
            }

            if (hand.Count((p) => IsValue(p, 'T')) == 1 &&
                hand.Count((p) => IsValue(p, 'J')) == 1 &&
                hand.Count((p) => IsValue(p, 'Q')) == 1 &&
                hand.Count((p) => IsValue(p, 'K')) == 1 &&
                hand.Count((p) => IsValue(p, 'A')) == 1)
            {
                highCard = 'A';
                return true;
            }

            return false;
        }

        private static bool IsStraightFlush(string[] hand, out char highCard)
        {
            return IsStraight(hand, out highCard) && IsFlush(hand, out highCard);
        }

        private static bool IsFlush(string[] hand, out char highCard)
        {
            if (IsSameSuit(hand))
            {
                highCard = hand[^1][0];
                return true;
            }

            highCard = default;
            return false;
        }

        private static bool IsStraight(string[] hand, out char highCard)
        {
            highCard = default;

            for (int i = 0; i < hand.Length - 1; i++)
            {
                string first = hand[i];
                string second = hand[i + 1];

                int x = GetCardValue(first);
                int y = GetCardValue(second);

                if (x != y - 1)
                {
                    return false;
                }
            }

            highCard = hand[^1][0];
            return true;
        }

        private static bool IsFullHouse(string[] hand, out char highCard)
        {
            highCard = default;

            if (!IsThreeOfAKind(hand, out char threeValue))
            {
                return false;
            }

            foreach (char value in Values.Except(new[] { threeValue }))
            {
                if (IsPair(hand, value, out _))
                {
                    highCard = threeValue;
                    return true;
                }
            }

            return false;
        }

        private static bool IsFourOfAKind(string[] hand, out char highCard)
        {
            foreach (char value in Values)
            {
                if (hand.Count((p) => IsValue(p, value)) == 4)
                {
                    highCard = value;
                    return true;
                }
            }

            highCard = default;
            return false;
        }

        private static bool IsThreeOfAKind(string[] hand, out char highCard)
        {
            foreach (char value in Values)
            {
                if (hand.Count((p) => IsValue(p, value)) == 3)
                {
                    highCard = value;
                    return true;
                }
            }

            highCard = default;
            return false;
        }

        private static bool IsTwoPair(string[] hand, out char highCard)
        {
            highCard = default;

            if (!IsPair(hand, out char firstPairValue))
            {
                return false;
            }

            foreach (char value in Values.Except(new[] { firstPairValue }))
            {
                if (IsPair(hand, value, out char secondPairValue))
                {
                    highCard = firstPairValue > secondPairValue ? firstPairValue : secondPairValue;
                    return true;
                }
            }

            return false;
        }

        private static bool IsPair(string[] hand, out char highCard)
        {
            foreach (char value in Values)
            {
                if (hand.Count((p) => IsValue(p, value)) == 2)
                {
                    highCard = value;
                    return true;
                }
            }

            highCard = default;
            return false;
        }

        private static bool IsPair(string[] hand, char value, out char highCard)
        {
            if (hand.Count((p) => IsValue(p, value)) == 2)
            {
                highCard = value;
                return true;
            }

            highCard = default;
            return false;
        }

        private static int GetCardValue(string card)
        {
            return GetCardValue(card[0]);
        }

        private static int GetCardValue(char value)
        {
            return value switch
            {
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => 0,
            };
        }

        private IList<string> ReadHands()
        {
            using var stream = ReadResource();
            using var reader = new StreamReader(stream);

            var hands = new List<string>();

            string? line = null;

            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                hands.Add(line);
            }

            return hands;
        }
    }
}
