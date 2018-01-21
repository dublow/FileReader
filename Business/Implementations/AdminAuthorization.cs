using Business.Interfaces;

namespace Business.Implementations
{
    public class AdminAuthorization : Authorization
    {
        public AdminAuthorization(IFileReader fileReader) : base(fileReader)
        { }

        public override bool CanRead(string path)
        {
            return true;
        }
    }
}
