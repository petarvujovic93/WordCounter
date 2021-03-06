using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Rest.Client;
using WordCounter.Rest.WordCounterApi.DataContracts.Base;
using WordCounter.Rest.WordCounterApi.DataContracts.Commands;
using WordCounter.Rest.WordCounterApi.DataContracts.Models;
using WordCounter.Rest.WordCounterApi.Mangers.Interface;

namespace WordCounter.Rest.WordCounterApi.Mangers
{
    public class FileManager : IWordCounterManger
    {
        CountResult IWordCounterManger.Count(Request request)
        {
            var task = Task.Run(() => CountAsync(request));
            task.Wait();
            return task.Result;
        }
        public Task<CountResult> CountAsync(Request request)
        {
            var apiManager = new ApiManager<FileCommand, CountResult>();
            return apiManager.Upload("v1/word-counter/count-from-file", request as FileCommand);
        }
        
    }
}
