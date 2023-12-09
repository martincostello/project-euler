// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using MartinCostello.ProjectEuler;

if (args == null || args.Length < 1)
{
    Console.WriteLine("No puzzle specified.");
    return -1;
}

IPuzzle? puzzle;

if (!int.TryParse(args[0], NumberStyles.Integer & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out int number) ||
    number < 1 ||
    (puzzle = Create(number)) is null)
{
    Console.WriteLine("The puzzle number specified is invalid.");
    return -1;
}

args = args[1..];

return Solve(puzzle, args);

static int Solve(IPuzzle puzzle, string[] args)
{
    Console.WriteLine();
    Console.WriteLine("Project Euler - Puzzle {0}", puzzle.GetType().Name.Replace("Puzzle", string.Empty, StringComparison.Ordinal).TrimStart('0'));
    Console.WriteLine();

    Console.WriteLine(puzzle.Question);

    var timeProvider = TimeProvider.System;
    long started = timeProvider.GetTimestamp();

    int result = puzzle.Solve(args);

    if (result == 0)
    {
        long solved = timeProvider.GetTimestamp();
        var duration = timeProvider.GetElapsedTime(started, solved);

        Console.WriteLine();
        Console.WriteLine("Answer: {0}", puzzle.Answer);
        Console.WriteLine();

        if (duration.TotalNanoseconds < 1_000)
        {
            Console.WriteLine($"Took {duration.Nanoseconds:N2}ns.");
        }
        else if (duration.TotalMicroseconds < 1_000)
        {
            Console.WriteLine($"Took {duration.TotalMicroseconds:N2}μs.");
        }
        else if (duration.TotalMilliseconds < 1_000)
        {
            Console.WriteLine($"Took {duration.TotalMilliseconds:N2}ms.");
        }
        else
        {
            Console.WriteLine($"Took {duration.TotalSeconds:N2}s.");
        }

        Console.WriteLine();
    }

    return result;
}

static IPuzzle? Create(int number)
{
    var type = GetType(number);

    if (type is null)
    {
        return null;
    }

    return CreateForType(type);
}

static IPuzzle CreateForType(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type type)
{
    if (Activator.CreateInstance(type) is not IPuzzle puzzle)
    {
        throw new InvalidOperationException("The puzzle number specified is invalid.");
    }

    return puzzle;
}

[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
[UnconditionalSuppressMessage("Trimmer", "IL2057", Justification = "Assembly is trim rooted.")]
static Type? GetType(int number)
{
    if (number < 1)
    {
        return null;
    }

    string typeName = string.Format(
        CultureInfo.InvariantCulture,
        "MartinCostello.ProjectEuler.Puzzles.Puzzle{0:000}, ProjectEuler",
        number);

    var type = Type.GetType(typeName);

    if (type is null || type.IsAssignableFrom(typeof(IPuzzle)))
    {
        return null;
    }

    return type;
}
