using System;
using System.Collections.Generic;
using System.Text;
using WordCounter.Business.Implementations;
using WordCounter.Business.Interface;

namespace WordCounter.Business
{
    public class FileReaderFactory
    {
        public static IFileReader GetInstance(string fileType)
        {
            switch (fileType.ToLower())
            {
                case ".txt":
                    return new TextFileReader();
                default:
                    throw new NotImplementedException();
                    
            }
        }
    }
}
