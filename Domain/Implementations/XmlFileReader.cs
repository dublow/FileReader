using Domain.Interfaces;
using System;
using System.IO;
using Common.Extensions;
using System.Xml.Linq;

namespace Domain.Implementations
{
    public class XmlFileReader : IFileReader
    {
        public IEncryptor Encryptor { get; private set; }

        public XmlFileReader(IEncryptor encryptor = null)
        {
            EnsureEncryption(encryptor);
        }

        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            var xmlAsString = File.ReadAllText(path);

            if (!xmlAsString.TryParse(out XElement xml))
                throw new InvalidOperationException("Content file is not a XML");

            return Encryptor.Encrypt(xmlAsString);
        }

        public void SetEncryptor(IEncryptor encryptor)
        {
            EnsureEncryption(encryptor);
        }

        private void EnsureEncryption(IEncryptor encryptor = null)
        {
            Encryptor = encryptor == null
                ? VoidEncryptor.Instance
                : encryptor;
        }
    }
}
