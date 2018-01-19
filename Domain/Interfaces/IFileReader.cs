namespace Domain.Interfaces
{
    public interface IFileReader
    {
        IEncryptor Encryptor { get; }
        string Read(string path);
    }
}
