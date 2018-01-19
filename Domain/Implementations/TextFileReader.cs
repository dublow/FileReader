using Domain.Interfaces;
using System;
using System.IO;

namespace Domain.Implementations
{
    public class TextFileReader : IFileReader
    {
        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            return File.ReadAllText(path);
        }
    }
}
