using System;
using System.Collections.Generic;
using System.Text;

namespace WordCounter.Business.Interface
{
    public interface IWordCounter
    {
        int Count(string text);
    }
}
