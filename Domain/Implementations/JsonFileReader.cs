using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Implementations
{
    public class JsonFileReader : IFileReader
    {
        public IEncryptor Encryptor => throw new NotImplementedException();

        public string Read(string path)
        {
            throw new NotImplementedException();
        }
    }
}
