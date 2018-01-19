using Domain.Interfaces;
using System;

namespace Domain.Implementations
{
    public class XmlFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "<?xml version=\"1.0\"?><text>Hello world!</text>";
        }
    }
}
