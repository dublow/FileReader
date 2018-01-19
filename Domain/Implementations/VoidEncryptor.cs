using Domain.Interfaces;
using System;

namespace Domain.Implementations
{
    public class VoidEncryptor : IEncryptor
    {
        [ThreadStatic]
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
