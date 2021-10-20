using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.Service.Interfaces;

namespace WordCounterUI.Controllers
{
    public class WordCounterController : Controller
    {
        private readonly IWordCounterService _wordCounterService;
        public WordCounterController(IWordCounterService wordCounterService)
        {
            _wordCounterService = wordCounterService;
        }

        [HttpPost]
        public int CountFromInput(string textInput)
        {
            return _wordCounterService.CountFromInput(textInput);
        }

        [HttpPost]
        public int CountFromDB()
        {
            return _wordCounterService.CountFromDB();
        }

        [HttpPost]
        public int CountFromFile(IFormCollection formCollection)
        {
            var file = formCollection.Files[0];
            return (_wordCounterService.CountFromFile(file?.OpenReadStream(), file?.FileName));
        }
    }
}
