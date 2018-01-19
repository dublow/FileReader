using Domain.Helpers;
using Domain.Interfaces;
using System;
using System.IO;

namespace Domain.Implementations
{
    public class TextFileReader : IFileReader
    {
        public IEncryptor Encryptor { get; private set; }

        public TextFileReader(IEncryptor encryptor = null)
        {
            Encryptor = Ensures.CurrentOrDefaultEncryption(encryptor);
        }

        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            return Encryptor.Encrypt(File.ReadAllText(path));
        }

        public void SetEncryptor(IEncryptor encryptor)
        {
            Encryptor = Ensures.CurrentOrDefaultEncryption(encryptor);
        }
    }
}
