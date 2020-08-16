// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using MartinCostello.ProjectEuler.Puzzles;

    [EventPipeProfiler(EventPipeProfile.CpuSampling)]
    [MemoryDiagnoser]
    public class PuzzleBenchmarks
    {
        public static IEnumerable<object> Puzzles()
        {
            yield return new PuzzleInput<Puzzle001>("1000");
            yield return new PuzzleInput<Puzzle002>("4000000");
            yield return new PuzzleInput<Puzzle003>("600851475143");
            yield return new PuzzleInput<Puzzle004>("3");
            yield return new PuzzleInput<Puzzle005>("20");
            yield return new PuzzleInput<Puzzle006>("100");
            yield return new PuzzleInput<Puzzle007>("10001");
            yield return new PuzzleInput<Puzzle008>("13");
            yield return new PuzzleInput<Puzzle009>();
            yield return new PuzzleInput<Puzzle010>("2000000");
            yield return new PuzzleInput<Puzzle011>();
            yield return new PuzzleInput<Puzzle012>("500");
            yield return new PuzzleInput<Puzzle013>();
            yield return new PuzzleInput<Puzzle014>();
            yield return new PuzzleInput<Puzzle015>("20");
            yield return new PuzzleInput<Puzzle016>("1000");
            yield return new PuzzleInput<Puzzle017>("9999");
            yield return new PuzzleInput<Puzzle018>();
            yield return new PuzzleInput<Puzzle019>();
            yield return new PuzzleInput<Puzzle020>("100");
            yield return new PuzzleInput<Puzzle021>();
            yield return new PuzzleInput<Puzzle022>();
            yield return new PuzzleInput<Puzzle023>();
            yield return new PuzzleInput<Puzzle024>();
            yield return new PuzzleInput<Puzzle025>();
            yield return new PuzzleInput<Puzzle026>();
            yield return new PuzzleInput<Puzzle027>();
            yield return new PuzzleInput<Puzzle028>("1001");
            yield return new PuzzleInput<Puzzle029>("100");
            yield return new PuzzleInput<Puzzle030>("5");
            yield return new PuzzleInput<Puzzle031>("200");
            yield return new PuzzleInput<Puzzle033>();
            yield return new PuzzleInput<Puzzle034>();
            yield return new PuzzleInput<Puzzle035>("1000000");
            yield return new PuzzleInput<Puzzle036>();
            yield return new PuzzleInput<Puzzle037>();
            yield return new PuzzleInput<Puzzle038>();
            yield return new PuzzleInput<Puzzle039>();
            yield return new PuzzleInput<Puzzle040>();
            yield return new PuzzleInput<Puzzle041>();
            yield return new PuzzleInput<Puzzle042>();
            yield return new PuzzleInput<Puzzle043>();
            yield return new PuzzleInput<Puzzle044>();
            yield return new PuzzleInput<Puzzle045>();
            yield return new PuzzleInput<Puzzle046>();
            yield return new PuzzleInput<Puzzle047>("4");
            yield return new PuzzleInput<Puzzle048>("1000");
            yield return new PuzzleInput<Puzzle049>();
            yield return new PuzzleInput<Puzzle050>("1000000");
            yield return new PuzzleInput<Puzzle052>();
            yield return new PuzzleInput<Puzzle054>();
            yield return new PuzzleInput<Puzzle055>();
            yield return new PuzzleInput<Puzzle056>();
            yield return new PuzzleInput<Puzzle059>();
            yield return new PuzzleInput<Puzzle067>();
            yield return new PuzzleInput<Puzzle092>();
            yield return new PuzzleInput<Puzzle097>();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Puzzles))]
        public int Solve(PuzzleInput input)
            => input.Puzzle.Solve(input.Args);

        public sealed class PuzzleInput<T> : PuzzleInput
            where T : IPuzzle, new()
        {
            public PuzzleInput(params string[] args)
                : base(args)
            {
            }

            public override IPuzzle Puzzle { get; } = new T();
        }

        public abstract class PuzzleInput
        {
            protected PuzzleInput(params string[] args)
            {
                Args = args;
            }

            public string[] Args { get; }

            public abstract IPuzzle Puzzle { get; }

            public override string ToString()
                => Puzzle.GetType().Name.Replace("Puzzle", string.Empty, StringComparison.Ordinal);
        }
    }
}
