﻿using Business.Interfaces;

namespace Business.Implementations
{
    public class UserAuthorization : Authorization
    {
        public UserAuthorization(IFileReader fileReader) : base(fileReader)
        { }

        public override bool CanRead(string path)
        {
            return 
                !string.IsNullOrEmpty(path)
                && !path.Contains("admin");
        }
    }
}
