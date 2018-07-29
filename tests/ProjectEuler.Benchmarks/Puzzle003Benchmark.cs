// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Benchmarks
{
    public class Puzzle003Benchmark : PuzzleBenchmark<Puzzles.Puzzle003>
    {
        public Puzzle003Benchmark()
            : base()
        {
            Arguments = new[] { "600851475143" };
        }
    }
}
