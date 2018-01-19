﻿namespace Domain.Interfaces
{
    public interface IEncryption
    {
        IEncryptor Encryptor { get; }
        void SetEncryptor(IEncryptor encryptor);
    }
}
