using Domain.Interfaces;
using System;
using System.IO;
using Common.Extensions;

namespace Domain.Implementations
{
    public class XmlFileReader : IFileReader
    {
        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            var xmlAsString = File.ReadAllText(path);

            if (!xmlAsString.TryParse(out var xml))
                throw new InvalidOperationException("Content file is not a XML");

            return xmlAsString;
        }
    }
}
