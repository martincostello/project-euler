// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Benchmarks
{
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class PuzzleBenchmarks
    {
        public static IEnumerable<object> Puzzles()
        {
            yield return new PuzzleInput<Puzzles.Puzzle001>("1000");
            yield return new PuzzleInput<Puzzles.Puzzle002>("4000000");
            yield return new PuzzleInput<Puzzles.Puzzle003>("600851475143");
        }

        [Benchmark]
        [ArgumentsSource(nameof(Puzzles))]
        public int Solve(PuzzleInput input)
            => input.Puzzle.Solve(input.Args);

        public sealed class PuzzleInput<T> : PuzzleInput
            where T : IPuzzle, new()
        {
            public PuzzleInput(string value)
                : base(value)
            {
            }

            public override IPuzzle Puzzle { get; } = new T();
        }

        public abstract class PuzzleInput
        {
            protected PuzzleInput(string value)
            {
                Args = new[] { value };
            }

            public string[] Args { get; }

            public abstract IPuzzle Puzzle { get; }

            public override string ToString()
                => Puzzle.GetType().Name;
        }
    }
}
