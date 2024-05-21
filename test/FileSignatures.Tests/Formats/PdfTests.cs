using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileSignatures.Formats;
using Xunit;

namespace FileSignatures.Tests.Formats;

public class PdfTests
{
    private static readonly byte[] PdfHeader = "%PDF"u8.ToArray();
    private const int MaxFileHeaderSize = 1024;

    public static IEnumerable<object[]> MatchHeaderAtAnyPlaceInFileHeaderData =>
        new List<object[]>
        {
            new object[] { Enumerable.Range(0, 42).Select(i => (byte)i).ToArray() },
            new object[] { Array.Empty<byte>() },
            new object[] { Enumerable.Range(0, MaxFileHeaderSize - PdfHeader.Length).Select(i => (byte)i).ToArray() },
        };

    [Theory]
    [MemberData(nameof(MatchHeaderAtAnyPlaceInFileHeaderData))]
    public void MatchPdfHeaderAtAnyPlaceInFileHeader(byte[] data)
    {
        var format = new Pdf();
        byte[] fileHeader = data.Concat(PdfHeader).ToArray();

        using var ms = new MemoryStream(fileHeader);
        var result = format.IsMatch(ms);

        Assert.True(result);
    }

    [Fact]
    public void MatchAdobePdfHeaderInFileHeader()
    {
        var format = new AdobePdf();
        byte[] fileHeader = Enumerable
            .Range(0, 42)
            .Select(i => (byte)i)
            .Concat("%!PS-Adobe-1.3 PDF-1.5"u8.ToArray()).ToArray();

        using var ms = new MemoryStream(fileHeader);
        var result = format.IsMatch(ms);

        Assert.True(result);
    }

    [Fact]
    public void DoesNotMatchPdfHeaderOutsideFileHeader()
    {
        var format = new Pdf();
        byte[] fileHeader = Enumerable
            .Range(0, MaxFileHeaderSize)
            .Select(i => (byte)i)
            .Concat(PdfHeader).ToArray();

        using var ms = new MemoryStream(fileHeader);
        var result = format.IsMatch(ms);

        Assert.False(result);
    }

    [Fact]
    public void DoesNotMatchContentSmallerThanHeader()
    {
        var format = new Pdf();
        byte[] header = [0x25, 0x50, 0x44];

        using var ms = new MemoryStream(header);
        var result = format.IsMatch(ms);

        Assert.False(result);
    }

    [Theory]
    [InlineData(new byte[] { 0x25, 0x51, 0x50, 0x44, 0x46 })]
    [InlineData(new byte[] { 0x25, 0x50, 0x44, 0x64 })]
    public void DoesNotMatchDifferentHeader(byte[] header)
    {
        var format = new Pdf();

        using var ms = new MemoryStream(header);
        var result = format.IsMatch(ms);

        Assert.False(result);
    }
}