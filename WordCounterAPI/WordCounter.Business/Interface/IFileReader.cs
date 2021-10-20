using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordCounter.Business.Interface
{
    public interface IFileReader
    {
        string Read(Stream FileContent);
    }
}
