using Common.Extensions;
using Domain.Helpers;
using Domain.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Domain.Implementations
{
    public class JsonFileReader : IFileReader, IEncryption
    {
        public IEncryptor Encryptor { get; private set; }

        public JsonFileReader(IEncryptor encryptor = null)
        {
            Encryptor = Ensures.CurrentOrDefaultEncryption(encryptor);
        }

        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            var jsonAsString = File.ReadAllText(path);

            if (!jsonAsString.TryParse(out JObject xml))
                throw new InvalidOperationException("Content file is not a Json");

            return Encryptor.Encrypt(jsonAsString);
        }

        public void SetEncryptor(IEncryptor encryptor)
        {
            Encryptor = Ensures.CurrentOrDefaultEncryption(encryptor);
        }
    }
}
