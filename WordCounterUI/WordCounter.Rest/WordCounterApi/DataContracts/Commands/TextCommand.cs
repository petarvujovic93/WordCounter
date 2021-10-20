using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WordCounter.Rest.WordCounterApi.DataContracts.Base;

namespace WordCounter.Rest.WordCounterApi.DataContracts.Commands
{
    public class TextCommand : Request
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
