using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WordCounter.Service.Interfaces;

namespace WordCounter.Service.Implementations
{
    public class WordCounterServiceImplementationMock : IWordCounterService
    {
        private int _mockResult = 33;
        public int CountFromDB()
        {
            return _mockResult;
        }

        public int CountFromFile(Stream streamm, string name)
        {
            return _mockResult;
        }

        public int CountFromInput(string text)
        {
            return _mockResult;
        }
    }
}
