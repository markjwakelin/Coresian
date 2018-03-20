using System;
using Coresian.Interfaces.Abstractions;

namespace Coresian.Abstractions
{
    public class Converter : IConverter
    {

        public byte[] FromBase64(string content)
        {
            return Convert.FromBase64String(content);
        }

        public string ToBase64(byte[] content, int offset = 0, int? length = null, Base64FormattingOptions formattingOptions = Base64FormattingOptions.None)
        {
            if (!length.HasValue)
                length = content.Length - offset;
            return Convert.ToBase64String(content, offset, length.Value, formattingOptions);
        }
    }
}
