// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=42</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle042 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "How many are triangle words are in the word data?";

    /// <summary>
    /// Returns the score of the specified word.
    /// </summary>
    /// <param name="word">The word to get the score for.</param>
    /// <returns>
    /// The score for the word specified by <paramref name="word"/>.
    /// </returns>
    internal static int GetScore(string word)
    {
        int score = 0;
        int length = word.Length;

        for (int i = 0; i < length; i++)
        {
            score += word[i] - 'A' + 1;
        }

        return score;
    }

    /// <summary>
    /// Returns the triangle number at the specified position in the sequence of triangle numbers.
    /// </summary>
    /// <param name="n">The position in the sequence to get the triangle number of.</param>
    /// <returns>
    /// The triangle number in the sequence at the position specified by <paramref name="n"/>.
    /// </returns>
    internal static int TriangleNumber(int n) => n * (n + 1) / 2;

    /// <summary>
    /// Reads the words from the data for the puzzle.
    /// </summary>
    /// <returns>
    /// An <see cref="IList{T}"/> that returns the words associated with the puzzle.
    /// </returns>
    internal IList<string> ReadWords()
    {
        using var stream = ReadResource();
        using var reader = new StreamReader(stream);

        string rawWords = reader.ReadToEnd();

        string[] split = rawWords.Split(',');

        var words = new List<string>(split.Length);

        foreach (string word in split)
        {
            words.Add(word.Trim('\"'));
        }

        return words;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        IList<string> words = ReadWords();

        int maximumLength = words.Max((p) => p.Length);
        int maximumScore = GetScore(new('Z', maximumLength));

        var triangleNumbers = new HashSet<int>(maximumScore);

        for (int n = 1; n <= maximumScore; n++)
        {
            int triangleNumber = TriangleNumber(n);

            if (triangleNumber > maximumScore)
            {
                break;
            }

            triangleNumbers.Add(triangleNumber);
        }

        Answer = words.Select(GetScore).Count(triangleNumbers.Contains);

        return 0;
    }
}
