// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class containing tests for the <see cref="Puzzle022"/> class. This class cannot be inherited.
/// </summary>
public static class Puzzle022Tests
{
    [Theory]
    [InlineData("COLIN", 938, 49714)]
    public static void Puzzle022_Score_Returns_Correct_Value(string name, int position, int expected)
    {
        // Act
        long actual = Puzzle022.Score(name, position);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(937, "COLIN")]
    public static void Puzzle022_ReadNames_Sorts_Names(int index, string name)
    {
        // Arrange
        var target = new Puzzle022();

        // Act
        IList<string> names = target.ReadNames();

        // Assert
        Assert.True(names.Count >= index);
        Assert.Equal(name, names[index]);
    }

    [Fact]
    public static void Puzzle022_Returns_Correct_Solution()
    {
        // Arrange
        int expected = 871_198_282;

        // Act and Assert
        Puzzles.AssertSolution<Puzzle022>(expected);
    }
}
