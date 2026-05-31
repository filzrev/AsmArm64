// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.
#if NETSTANDARD2_0

using System.Runtime.CompilerServices;

namespace AsmArm64;

internal static partial class PolyfillExtensions
{
    public static int ReadAtLeast(this Stream target, Span<byte> buffer, int minimumBytes, bool throwOnEndOfStream = true)
    {
        if (minimumBytes < 0)
            throw new ArgumentOutOfRangeException(nameof(minimumBytes), "Non-negative number required");

        if (buffer.Length < minimumBytes)
            throw new ArgumentOutOfRangeException(nameof(minimumBytes), "Must not be greater than the length of the buffer.");

        int totalRead = 0;
        while (totalRead < minimumBytes)
        {
            int read = target.Read(buffer.Slice(totalRead));
            if (read == 0)
            {
                if (throwOnEndOfStream)
                    throw new EndOfStreamException("Unable to read beyond the end of the stream.");

                return totalRead;
            }

            totalRead += read;
        }

        return totalRead;
    }

    public static bool TryWrite(
        this Span<char> destination,
        string value,
        out int charsWritten)
    {
        return TryWrite(destination, null, value, out charsWritten);
    }

    public static bool TryWrite(
        this Span<char> destination,
        IFormatProvider? provider,
        string value,
        out int charsWritten)
    {
        if (provider != null)
            throw new ArgumentException();

        string text = value;
        if (text.Length > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        text.AsSpan().CopyTo(destination);
        charsWritten = text.Length;
        return true;
    }
}
#endif
