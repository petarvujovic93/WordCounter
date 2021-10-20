using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WordCounter.Rest.WordCounterApi.DataContracts.Commands;
using WordCounter.Rest.WordCounterApi.DataContracts.Enums;
using WordCounter.Rest.WordCounterApi.Mangers.Factory;
using WordCounter.Rest.WordCounterApi.Mangers.Interface;
using WordCounter.Service.Interfaces;

namespace WordCounter.Service.Implementations
{
    public class WordCounterServiceImplementationAPI : IWordCounterService
    {
        public int CountFromDB()
        {
            IWordCounterManger manager = WordCounterManagerFactory.CreateManager(CountType.DB);
            var result = manager.Count(new DBCommand());
            return result?.TotalCount ?? 0;
        }

        public int CountFromFile(Stream stream, string name)
        {
            IWordCounterManger manager = WordCounterManagerFactory.CreateManager(CountType.File);
            var result = manager.Count(new FileCommand { Content = stream, Name = name });
            return result?.TotalCount ?? 0;
        }

        public int CountFromInput(string text)
        {
            IWordCounterManger manager = WordCounterManagerFactory.CreateManager(CountType.Text);
            var result = manager.Count(new TextCommand { Text = text });
            return result?.TotalCount ?? 0;
        }
    }
}
