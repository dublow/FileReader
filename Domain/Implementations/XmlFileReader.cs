using Domain.Interfaces;
using System;
using System.IO;
using Common.Extensions;
using System.Xml.Linq;
using Domain.Helpers;

namespace Domain.Implementations
{
    public class XmlFileReader : IFileReader
    {
        public IEncryptor Encryptor { get; private set; }

        public XmlFileReader(IEncryptor encryptor = null)
        {
            Encryptor = Ensures.CurrentOrDefaultEncryption(encryptor);
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
            Encryptor = Ensures.CurrentOrDefaultEncryption(encryptor);
        }
    }
}
