using System;
using System.Collections.Generic;
using System.Text;
using WordCounter.Rest.WordCounterApi.DataContracts.Enums;
using WordCounter.Rest.WordCounterApi.Mangers.Interface;

namespace WordCounter.Rest.WordCounterApi.Mangers.Factory
{
    public class WordCounterManagerFactory
    {
        public static IWordCounterManger CreateManager(CountType countType)
        {
            IWordCounterManger manager = null;
            switch (countType)
            {
                case CountType.Text:
                    manager = new TextManager();
                    break;
                case CountType.DB:
                    manager = new DBManager();
                    break;
                case CountType.File:
                    manager = new FileManager();
                    break;
            }

            return manager;
        }
    }
}
