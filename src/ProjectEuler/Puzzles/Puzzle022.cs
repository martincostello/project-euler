// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=22</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle022 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "What is the total of all the name scores in the names data?";

    /// <summary>
    /// Returns the score for a name when at a specified position.
    /// </summary>
    /// <param name="name">The name to get the score for.</param>
    /// <param name="position">The original position of the name in the set it belongs to.</param>
    /// <returns>
    /// The score of <paramref name="name"/> when at <paramref name="position"/>.
    /// </returns>
    internal static int Score(string name, int position)
    {
        int score = 0;
        int length = name.Length;

        for (int i = 0; i < length; i++)
        {
            score += name[i] - 'A' + 1;
        }

        return score * position;
    }

    /// <summary>
    /// Reads the sorted list of names from the data associated with the puzzle.
    /// </summary>
    /// <returns>
    /// An <see cref="List{T}"/> that returns the sorted list of names.
    /// </returns>
    internal List<string> ReadNames()
    {
        using var stream = ReadResource();
        using var reader = new StreamReader(stream);

        var names = new List<string>();

        var namesText = reader.ReadToEnd().AsSpan();

        foreach (var range in namesText.Split(','))
        {
            names.Add(namesText[range].Trim(['"', '\r', '\n']).ToString());
        }

        names.TrimExcess();
        names.Sort();

        return names;
    }

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        List<string> names = ReadNames();

        int total = 0;

        for (int i = 0; i < names.Count; i++)
        {
            total += Score(names[i], i + 1);
        }

        Answer = total;

        return 0;
    }
}
