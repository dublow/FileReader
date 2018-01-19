using Domain.Interfaces;
using System;
using System.IO;

namespace Domain.Implementations
{
    public class TextFileReader : IFileReader
    {
        private IEncryptor _encryptor;

        public TextFileReader(IEncryptor encryptor = null)
        {
            EnsureEncryption(encryptor);
        }

        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            return _encryptor.Encrypt(File.ReadAllText(path));
        }

        public void SetEncryptor(IEncryptor encryptor)
        {
            EnsureEncryption(encryptor);
        }

        private void EnsureEncryption(IEncryptor encryptor = null)
        {
            _encryptor = encryptor == null
                ? VoidEncryptor.Instance
                : encryptor;
        }
    }
}
