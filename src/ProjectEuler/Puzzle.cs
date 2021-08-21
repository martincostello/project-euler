// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.IO;
using System.Reflection;

namespace MartinCostello.ProjectEuler;

/// <summary>
/// The base class for puzzles.
/// </summary>
public abstract class Puzzle : IPuzzle
{
    /// <inheritdoc />
    public abstract string Question { get; }

    /// <inheritdoc />
    public object? Answer { get; protected set; }

    /// <summary>
    /// Gets the minimum number of arguments required to solve the puzzle.
    /// </summary>
    protected virtual int MinimumArguments => 0;

    /// <inheritdoc />
    public virtual int Solve(string[] args)
    {
        if (!EnsureArguments(args, MinimumArguments))
        {
            Console.WriteLine(
                "At least {0:N0} argument{1} {2} required.",
                MinimumArguments,
                MinimumArguments == 1 ? string.Empty : "s",
                MinimumArguments == 1 ? "is" : "are");

            return -1;
        }

        return SolveCore(args);
    }

    /// <summary>
    /// Ensures that the specified number of arguments are present.
    /// </summary>
    /// <param name="args">The input arguments to the puzzle.</param>
    /// <param name="minimumLength">The minimum number of arguments required.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="args"/> is at least
    /// <paramref name="minimumLength"/> in length; otherwise <see langword="false"/>.
    /// </returns>
    protected static bool EnsureArguments(ICollection<string> args, int minimumLength) => args.Count >= minimumLength;

    /// <summary>
    /// Tries to parse the specified <see cref="string"/> as a 32-bit integer.
    /// </summary>
    /// <param name="value">The value to try and parse.</param>
    /// <param name="result">When the method returns, contains the parsed value, if successful.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> was parsed successfully; otherwise <see langword="false"/>.
    /// </returns>
    protected static bool TryParseInt32(string value, out int result)
    {
        return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Tries to parse the specified <see cref="string"/> as a 64-bit integer.
    /// </summary>
    /// <param name="value">The value to try and parse.</param>
    /// <param name="result">When the method returns, contains the parsed value, if successful.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> was parsed successfully; otherwise <see langword="false"/>.
    /// </returns>
    protected static bool TryParseInt64(string value, out long result)
    {
        return long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Returns the <see cref="Stream"/> associated with the resource for the puzzle.
    /// </summary>
    /// <returns>
    /// A <see cref="Stream"/> containing the resource associated with the puzzle.
    /// </returns>
    protected Stream ReadResource()
    {
        var thisType = GetType().GetTypeInfo();
        string name = FormattableString.Invariant($"MartinCostello.{thisType.Assembly.GetName().Name}.Puzzles.{thisType.Name}.Data.txt");

        // HACK Work around https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/2968
        var stream = thisType.Assembly.GetManifestResourceStream(name);
        return stream!;
    }

    /// <summary>
    /// Solves the puzzle given the specified arguments.
    /// </summary>
    /// <param name="args">The input arguments to the puzzle.</param>
    /// <returns>The exit code the application should return.</returns>
    protected abstract int SolveCore(string[] args);
}
