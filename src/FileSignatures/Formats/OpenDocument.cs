using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of an OpenDocument file.
/// </summary>
public abstract class OpenDocument : Zip
{
    private const int SubsignatureOffset = 30;

    protected OpenDocument(byte[] subsignature, string mediaType, string extension) : base(SubsignatureOffset + subsignature.Length, mediaType, extension)
    {
        Subsignature = new ReadOnlyCollection<byte>(subsignature); ;
    }

    /// <summary>
    /// Gets the subsignature of the OpenDocument file.
    /// This will be the media type in byte format e.g. 'mimetypeapplication/vnd.oasis.opendocument.presentation'
    /// </summary>
    public ReadOnlyCollection<byte> Subsignature { get; }

    public override bool IsMatch(Stream stream)
    {
        if (!base.IsMatch(stream))
            return false;

        stream.Position = SubsignatureOffset;

        for (int i = 0; i < Subsignature.Count; i++)
        {
            var b = stream.ReadByte();
            if (b != Subsignature[i])
            {
                return false;
            }
        }

        return true;
    }
}
