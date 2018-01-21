using Business.Implementations;
using Business.Interfaces;

namespace Business.Helpers
{
    internal static class Ensures
    {
        public static IEncryptor CurrentOrDefaultEncryption(IEncryptor encryptor)
        {
            return encryptor == null
                ? VoidEncryptor.Instance
                : encryptor;
        }
    }
}
