using Domain.Interfaces;
using System;

namespace Domain.Implementations
{
    public class UserAuthorization : Authorization
    {
        public UserAuthorization(IFileReader fileReader) : base(fileReader)
        { }

        public override bool CanRead(string path)
        {
            throw new NotImplementedException();
        }
    }
}
