// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Diagnostics;
using MartinCostello.ProjectEuler;

if (args == null || args.Length < 1)
{
    Console.WriteLine("No puzzle specified.");
    return -1;
}

Type? type;

if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out int puzzle) ||
    puzzle < 1 ||
    (type = GetPuzzleType(puzzle)) == null)
{
    Console.WriteLine("The puzzle number specified is invalid.");
    return -1;
}

args = args[1..];

return SolvePuzzle(type, args);

static int SolvePuzzle(Type type, string[] args)
{
    IPuzzle? puzzle = Activator.CreateInstance(type) as IPuzzle;

    Console.WriteLine();
    Console.WriteLine("Project Euler - Puzzle {0}", type.Name.Replace("Puzzle", string.Empty, StringComparison.Ordinal).TrimStart('0'));
    Console.WriteLine();

    Console.WriteLine(puzzle!.Question);

    var stopwatch = Stopwatch.StartNew();

    int result = puzzle.Solve(args);

    if (result == 0)
    {
        stopwatch.Stop();

        Console.WriteLine();
        Console.WriteLine("Answer: {0}", puzzle.Answer);
        Console.WriteLine();

        if (stopwatch.Elapsed.TotalSeconds < 0.01f)
        {
            Console.WriteLine("Took <0.01 seconds.");
        }
        else
        {
            Console.WriteLine("Took {0:N2} seconds.", stopwatch.Elapsed.TotalSeconds);
        }

        Console.WriteLine();
    }

    return result;
}

static Type? GetPuzzleType(int number)
{
    string typeName = string.Format(
        CultureInfo.InvariantCulture,
        "MartinCostello.ProjectEuler.Puzzles.Puzzle{0:000}",
        number);

    return Type.GetType(typeName);
}
