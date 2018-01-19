using Domain.Implementations;
using Domain.Interfaces;

namespace Domain.Helpers
{
    internal static class Ensures
    {
        public static IEncryptor CurrentOrDefaultEncryption(IEncryptor encryptor = null)
        {
            return encryptor == null
                ? VoidEncryptor.Instance
                : encryptor;
        }
    }
}
