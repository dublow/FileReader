using Common.Extensions;
using Domain.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Domain.Implementations
{
    public class JsonFileReader : IFileReader
    {
        public IEncryptor Encryptor => throw new NotImplementedException();

        public string Read(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentNullException(nameof(path));

            var jsonAsString = File.ReadAllText(path);

            if (!jsonAsString.TryParse(out JObject xml))
                throw new InvalidOperationException("Content file is not a Json");

            return jsonAsString;
        }
    }
}
