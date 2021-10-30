// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using static MartinCostello.ProjectEuler.Benchmarks.PuzzleBenchmarks;

namespace MartinCostello.ProjectEuler.Benchmarks;

public static class BenchmarkTests
{
    public static IEnumerable<object[]> Benchmarks()
    {
        foreach (object puzzle in PuzzleBenchmarks.Puzzles())
        {
            yield return new object[] { puzzle };
        }
    }

    [Theory]
    [MemberData(nameof(Benchmarks))]
    public static void Can_Run_Benchmarks(PuzzleInput input)
    {
        // Arrange
        IPuzzle puzzle = input.Puzzle;
        string[] args = input.Args;

        // Act (no Assert)
        puzzle.Solve(args);
    }
}
