using Domain.Interfaces;

namespace Domain.Implementations
{
    public abstract class Authorization : IFileReader
    {
        private readonly IFileReader _fileReader;

        protected Authorization(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string Read(string path)
        {
            return CanRead(path)
                ? _fileReader.Read(path)
                : string.Empty;
        }

        public abstract bool CanRead(string path);
    }
}
