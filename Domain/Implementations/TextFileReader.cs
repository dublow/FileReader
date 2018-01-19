using Domain.Interfaces;
using System;

namespace Domain.Implementations
{
    public class TextFileReader : IFileReader<string>
    {
        public string Read()
        {
            return "Hello world!";
        }
    }
}
