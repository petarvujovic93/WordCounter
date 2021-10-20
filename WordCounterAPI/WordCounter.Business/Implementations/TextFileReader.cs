using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordCounter.Business.Implementations
{
    public class TextFileReader : Interface.IFileReader
    {
        public string Read(Stream FileContent)
        {
            var text = string.Empty;

            using (var streamReader = new StreamReader(FileContent))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }
    }
}
