using System;
using System.IO;
using System.Text;

namespace FileSignatures.Formats;

/// <summary>
/// Extensible Binary Meta Language (EBML) format.
/// </summary>
public abstract class Ebml : FileFormat, IFileFormatReader
{
    private const long EbmlHeaderId = 0x1A45DFA3;
    private const long DocTypeId = 0x4282;

    /// <summary>
    /// Initialises a new EBML container format.
    /// </summary>
    /// <param name="docType">The doctype in the EBML header to match.</param>
    /// <param name="mediaType">The media type of the format.</param>
    /// <param name="extension">The appropriate file extension for the format.</param>
    protected Ebml(string docType, string mediaType, string extension) : base([0x1A, 0x45, 0xDF, 0xA3], headerLength: 4, mediaType, extension)
    {
        DocType = docType;
    }

    public string DocType { get; }

    public IDisposable? Read(Stream stream)
    {
        if (stream == null || !stream.CanSeek)
            return null;

        var originalPosition = stream.Position;

        try
        {
            stream.Position = 0;
            return ReadEbmlHeader(stream);
        }
        catch (EndOfStreamException)
        {
            return null;
        }
        catch (InvalidDataException)
        {
            return null;
        }
        finally
        {
            stream.Position = originalPosition;
        }
    }

    public bool IsMatch(IDisposable? file)
    {
        if (file is not EbmlHeader header)
        {
            return false;
        }

        return string.Equals(header.DocType, DocType, StringComparison.OrdinalIgnoreCase);
    }

    private static EbmlHeader? ReadEbmlHeader(Stream stream)
    {
        if (stream == null || !stream.CanSeek)
            return null;

        // EBML header ID
        ulong id = ReadVInt(stream, removeMarker: false);

        if (id != EbmlHeaderId)
            return null;

        // EBML header size
        ulong headerSize = ReadVInt(stream, removeMarker: true);

        long remaining = stream.Length - stream.Position;

        if (headerSize > (ulong)remaining)
            return null;

        long headerEnd = stream.Position + (long)headerSize;

        while (stream.Position < headerEnd)
        {
            ulong elementId =
                ReadVInt(stream, removeMarker: false);

            ulong elementSize =
                ReadVInt(stream, removeMarker: true);

            long elementRemaining =
                headerEnd - stream.Position;

            if (elementSize > (ulong)elementRemaining)
                return null;

            if (elementId == DocTypeId)
            {
                if (elementSize > int.MaxValue)
                    return null;

                byte[] bytes = new byte[(int)elementSize];

                if (!ReadExactly(stream, bytes))
                    return null;


                string docType = Encoding.ASCII.GetString(bytes);
                return new EbmlHeader(docType);
            }

            stream.Position += (long)elementSize;
        }

        return null;
    }

    private static ulong ReadVInt(
        Stream stream,
        bool removeMarker)
    {
        int first = stream.ReadByte();

        if (first < 0)
            throw new EndOfStreamException();

        byte firstByte = (byte)first;

        int mask = 0x80;
        int length = 1;

        while ((firstByte & mask) == 0)
        {
            mask >>= 1;
            length++;

            if (length > 8)
                throw new InvalidDataException(
                    "Invalid EBML VINT.");
        }

        ulong value = firstByte;

        if (removeMarker)
            value &= (ulong)(mask - 1);

        for (int i = 1; i < length; i++)
        {
            int next = stream.ReadByte();

            if (next < 0)
                throw new EndOfStreamException();

            value = (value << 8) | (byte)next;
        }

        return value;
    }

    private static bool ReadExactly(
        Stream stream,
        byte[] buffer)
    {
        int offset = 0;

        while (offset < buffer.Length)
        {
            int read = stream.Read(
                buffer,
                offset,
                buffer.Length - offset);

            if (read == 0)
                return false;

            offset += read;
        }

        return true;
    }

    private sealed class EbmlHeader(string docType) : IDisposable
    {
        public string DocType { get; } = docType;

        public void Dispose() { } // Dummy implementation for IFileFormatReader compatability
    }
}