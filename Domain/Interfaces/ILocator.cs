﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Interfaces
{
    public interface ILocator
    {
        Stream GetStream(string path);
    }
}
