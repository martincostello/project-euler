// Copyright (c) Martin Costello, 2015. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Buffers;
using System.Text;

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
        byte[] encrypted = LoadText();

        byte[] alphabet = Enumerable.Range('a', 26)
            .Select((p) => (byte)p)
            .ToArray();

        var passwords = new List<byte[]>((int)Math.Pow(alphabet.Length, 3));

        for (int x = 0; x < alphabet.Length; x++)
        {
            for (int y = 0; y < alphabet.Length; y++)
            {
                for (int z = 0; z < alphabet.Length; z++)
                {
                    passwords.Add([alphabet[x], alphabet[y], alphabet[z]]);
                }
            }
        }

        var encoding = Encoding.ASCII;

        // Five most common English words
        string[] commonWords =
        [
            " the ",
            " of ",
            " and ",
            " a ",
            " to ",
        ];

        byte[][] words = commonWords.Select(encoding.GetBytes).ToArray();

        byte[] key = new byte[encrypted.Length];
        byte[] decrypted = new byte[encrypted.Length];

        foreach (byte[] password in passwords)
        {
            for (int i = 0; i < key.Length;)
            {
                key[i++] = password[0];
                key[i++] = password[1];
                key[i++] = password[2];
            }

            for (int i = 0; i < decrypted.Length; i++)
            {
                decrypted[i] = (byte)(encrypted[i] ^ key[i]);
            }

            ReadOnlySpan<byte> plaintext = decrypted;

            if (plaintext.IndexOf(words[0]) > -1 &&
                plaintext.IndexOf(words[1]) > -1 &&
                plaintext.IndexOf(words[2]) > -1 &&
                plaintext.IndexOf(words[3]) > -1 &&
                plaintext.IndexOf(words[4]) > -1)
            {
                Answer = decrypted.Select((p) => (int)p).Sum();
                break;
            }
        }

        return 0;
    }

    private byte[] LoadText()
    {
        using var stream = ReadResource();
        using var reader = new StreamReader(stream);

        string text = reader.ReadToEnd();

        string[] split = text.Split(',');

        return split
            .Select((p) => byte.Parse(p, CultureInfo.InvariantCulture))
            .ToArray();
    }
}
