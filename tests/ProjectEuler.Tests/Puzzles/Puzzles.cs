// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing methods for helping to test puzzles. This class cannot be inherited.
/// </summary>
internal static class Puzzles
{
    /// <summary>
    /// Asserts that the arguments to the specified puzzle type are invalid.
    /// </summary>
    /// <typeparam name="T">The type of the puzzle to assert on.</typeparam>
    /// <param name="args">The arguments to pass to the puzzle.</param>
    internal static void AssertInvalid<T>(string[] args)
        where T : IPuzzle, new()
    {
        // Arrange
        T puzzle = new T();

        // Act and Assert
        AssertInvalid(puzzle, args);
    }

    /// <summary>
    /// Asserts that the arguments to the specified puzzle are invalid.
    /// </summary>
    /// <param name="puzzle">The puzzle to assert on.</param>
    /// <param name="args">The arguments to pass to the puzzle.</param>
    internal static void AssertInvalid(IPuzzle puzzle, string[] args)
    {
        // Act
        int actual = puzzle.Solve(args);

        // Assert
        Assert.Equal(-1, actual);
    }

    /// <summary>
    /// Solves the specified puzzle type and asserts on the answer.
    /// </summary>
    /// <typeparam name="T">The type of the puzzle to solve.</typeparam>
    /// <param name="expected">The expected answer to the puzzle.</param>
    /// <returns>
    /// The solved puzzle of the type specified by <typeparamref name="T"/>.
    /// </returns>
    internal static T AssertSolution<T>(object expected)
        where T : IPuzzle, new()
    {
        return AssertSolution<T>(Array.Empty<string>(), expected);
    }

    /// <summary>
    /// Solves the specified puzzle type with the specified arguments and asserts on the answer.
    /// </summary>
    /// <typeparam name="T">The type of the puzzle to solve.</typeparam>
    /// <param name="args">The arguments to pass to the puzzle.</param>
    /// <param name="expected">The expected answer to the puzzle.</param>
    /// <returns>
    /// The solved puzzle of the type specified by <typeparamref name="T"/>.
    /// </returns>
    internal static T AssertSolution<T>(string[] args, object expected)
        where T : IPuzzle, new()
    {
        // Arrange
        T puzzle = new T();

        // Act and Assert
        AssertSolution(puzzle, args, expected);

        return puzzle;
    }

    /// <summary>
    /// Solves the specified puzzle with the specified arguments and asserts on the answer.
    /// </summary>
    /// <param name="puzzle">The puzzle to solve and assert on.</param>
    /// <param name="args">The arguments to pass to the puzzle.</param>
    /// <param name="expected">The expected answer to the puzzle.</param>
    internal static void AssertSolution(IPuzzle puzzle, string[] args, object expected)
    {
        // Act
        int result = puzzle.Solve(args);

        // Assert
        Assert.Equal(0, result);
        Assert.NotNull(puzzle.Answer);
        Assert.Equal(expected, puzzle.Answer);
    }
}
