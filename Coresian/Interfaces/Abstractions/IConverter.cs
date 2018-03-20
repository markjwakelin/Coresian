using System;

namespace Coresian.Interfaces.Abstractions
{
    public interface IConverter
    {
        byte[] FromBase64(string content);

        string ToBase64(byte[] content, int offset = 0, int? length = null,
            Base64FormattingOptions formattingOptions = Base64FormattingOptions.None);
    }
}