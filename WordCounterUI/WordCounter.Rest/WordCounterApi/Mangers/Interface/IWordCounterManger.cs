using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Rest.WordCounterApi.DataContracts.Base;
using WordCounter.Rest.WordCounterApi.DataContracts.Models;

namespace WordCounter.Rest.WordCounterApi.Mangers.Interface
{
    public interface IWordCounterManger
    {
        public CountResult Count(Request request);
        public Task<CountResult> CountAsync(Request request);
    }
}
