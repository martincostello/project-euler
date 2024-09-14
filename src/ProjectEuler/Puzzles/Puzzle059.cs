// Copyright (c) Martin Costello, 2015. All rights reserved.
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
        Span<char> key = stackalloc char[encrypted.Length];
        Span<char> decrypted = stackalloc char[encrypted.Length];

        // Five most common English words
        ReadOnlySpan<string> commonWords = [" the ", " of ", " and ", " a ", " to "];

        for (int i = 0; i < passwords.Length; i += KeyLength)
        {
            var password = passwords.Slice(i, KeyLength);

            for (int j = 0; j < key.Length; j += KeyLength)
            {
                key[j] = password[0];
                key[j + 1] = password[1];
                key[j + 2] = password[2];
            }

            for (int j = 0; j < decrypted.Length; j++)
            {
                decrypted[j] = (char)(encrypted[j] ^ key[j]);
            }

            if (decrypted.IndexOf(commonWords[0]) > -1 &&
                decrypted.IndexOf(commonWords[1]) > -1 &&
                decrypted.IndexOf(commonWords[2]) > -1 &&
                decrypted.IndexOf(commonWords[3]) > -1 &&
                decrypted.IndexOf(commonWords[4]) > -1)
            {
                int sum = 0;

                for (int k = 0; k < decrypted.Length; k++)
                {
                    sum += decrypted[k];
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
            int comma;
            int index = 0;

            while ((comma = value.IndexOf(',')) > -1)
            {
                buffer[index++] = ParseChar(value[..comma]);
                value = value[(comma + 1)..];
                length++;
            }

            if (value.Length > 0)
            {
                buffer[index++] = ParseChar(value);
                length++;
            }

            static char ParseChar(ReadOnlySpan<char> span)
                => (char)byte.Parse(span, CultureInfo.InvariantCulture);
        }).AsSpan()[..length];
    }
}
