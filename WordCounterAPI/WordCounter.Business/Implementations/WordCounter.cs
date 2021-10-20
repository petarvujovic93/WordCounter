using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WordCounter.Business.Interface;

namespace WordCounter.Business.Implementations
{
    public class WordCounter : IWordCounter
    {
        public int Count(string text)
        {
            string pattern = "[^\\w]";
            var words = Regex.Split(text, pattern, RegexOptions.IgnoreCase);

            return words.Where(w => !string.IsNullOrWhiteSpace(w)).Count();
        }
    }
}
