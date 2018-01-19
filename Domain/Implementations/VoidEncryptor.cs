using Domain.Interfaces;

namespace Domain.Implementations
{
    public class VoidEncryptor : IEncryptor
    {
        private static VoidEncryptor _instance;

        private VoidEncryptor()
        {  }

        public static VoidEncryptor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VoidEncryptor();
                return _instance;
            }
        }

        public string Encrypt(string content)
        {
            return content;
        }
    }
}
