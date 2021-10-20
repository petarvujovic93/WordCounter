using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordCounter.DataAccess.Repositories;

namespace WordCounter.DataAccess
{
    public class DataAccess
    {
        private readonly ITextRepository _textRepository;

        public DataAccess(ITextRepository textRepository)
        {
            _textRepository = textRepository;
        }

        public string GetText()
        {
            return _textRepository.GetAll().FirstOrDefault()?.Text1 ?? string.Empty;
        }
    }
}
