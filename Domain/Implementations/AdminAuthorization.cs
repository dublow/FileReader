using Domain.Interfaces;

namespace Domain.Implementations
{
    public class AdminAuthorization : Authorization
    {
        public AdminAuthorization(IFileReader fileReader) : base(fileReader)
        { }

        public override bool CanRead(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
