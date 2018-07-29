// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Benchmarks
{
    public class Puzzle001Benchmark : PuzzleBenchmark<Puzzles.Puzzle001>
    {
        public Puzzle001Benchmark()
            : base()
        {
            Arguments = new[] { "1000" };
        }
    }
}
