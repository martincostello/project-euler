﻿// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.ProjectEuler.Puzzles;

/// <summary>
/// A class representing the solution to <c>https://projecteuler.net/problem=59</c>. This class cannot be inherited.
/// </summary>
public sealed class Puzzle059 : Puzzle
{
    /// <inheritdoc />
    public override string Question => "What is the sum of the ASCII values in the decrypted text?";

    /// <inheritdoc />
    protected override int SolveCore(string[] args)
    {
        const int AlphabetLength = 26;
        const int KeyLength = 3;

        ReadOnlySpan<char> passwords = string.Create(
            AlphabetLength * AlphabetLength * AlphabetLength * KeyLength,
            "abcdefghijklmnopqrstuvwxyz",
            static (buffer, alphabet) =>
        {
            int i = 0;

            for (int x = 0; x < alphabet.Length; x++)
            {
                for (int y = 0; y < alphabet.Length; y++)
                {
                    for (int z = 0; z < alphabet.Length; z++)
                    {
                        buffer[i] = alphabet[x];
                        buffer[i + 1] = alphabet[y];
                        buffer[i + 2] = alphabet[z];
                        i += KeyLength;
                    }
                }
            }
        });

        var encrypted = LoadText();
        Span<char> decrypted = stackalloc char[encrypted.Length];

        for (int i = 0; i < passwords.Length; i += KeyLength)
        {
            var password = passwords.Slice(i, KeyLength);

            for (int j = 0; j < decrypted.Length; j += KeyLength)
            {
                decrypted[j] = (char)(encrypted[j] ^ password[0]);
                decrypted[j + 1] = (char)(encrypted[j + 1] ^ password[1]);
                decrypted[j + 2] = (char)(encrypted[j + 2] ^ password[2]);
            }

            ReadOnlySpan<char> span = decrypted;

            if (span.Contains("Euler", StringComparison.Ordinal))
            {
                int sum = 0;

                for (int j = 0; j < span.Length; j++)
                {
                    sum += span[j];
                }

                Answer = sum;
                break;
            }
        }

        return 0;
    }

    private ReadOnlySpan<char> LoadText()
    {
        using var stream = ReadResource();
        using var reader = new StreamReader(stream);

        int length = 0;
        ReadOnlySpan<char> text = reader.ReadToEnd();

        return string.Create(text.Length, text, (buffer, value) =>
        {
            foreach (var range in value.Split(','))
            {
                buffer[length++] = (char)byte.Parse(value[range], CultureInfo.InvariantCulture);
            }
        }).AsSpan()[..length];
    }
}
