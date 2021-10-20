using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordCounter.Service.Interfaces
{
    public interface IWordCounterService
    {
        public int CountFromInput(string text);
        public int CountFromDB();
        public int CountFromFile(Stream stream, string name);
    }
}
