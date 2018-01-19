using Domain.Interfaces;
using System.Linq;

namespace Domain.Implementations
{
    public class ReverseEncryptor : IEncryptor
    {
        public string Encrypt(string content)
        {
            if (string.IsNullOrEmpty(content))
                return content;

            return string.Concat(content.Reverse());
        }
    }
}
