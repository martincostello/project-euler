// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler;

/// <summary>
/// Defines a puzzle.
/// </summary>
public interface IPuzzle
{
    /// <summary>
    /// Gets the text of the puzzle's question.
    /// </summary>
    string Question { get; }

    /// <summary>
    /// Gets the answer to the puzzle.
    /// </summary>
    object? Answer { get; }

    /// <summary>
    /// Solves the puzzle given the specified arguments.
    /// </summary>
    /// <param name="args">The input arguments to the puzzle.</param>
    /// <returns>The exit code the application should return.</returns>
    int Solve(string[] args);
}
