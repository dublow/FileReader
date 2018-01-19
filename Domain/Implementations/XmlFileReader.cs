using Domain.Interfaces;
using System;
using System.IO;
using Common.Extensions;

namespace Domain.Implementations
{
    public class XmlFileReader : IFileReader
    {
        private IEncryptor _encryptor;

        public XmlFileReader(IEncryptor encryptor = null)
        {
            EnsureEncryption(encryptor);
        }

        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            var xmlAsString = File.ReadAllText(path);

            if (!xmlAsString.TryParse(out var xml))
                throw new InvalidOperationException("Content file is not a XML");

            return _encryptor.Encrypt(xmlAsString); ;
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
