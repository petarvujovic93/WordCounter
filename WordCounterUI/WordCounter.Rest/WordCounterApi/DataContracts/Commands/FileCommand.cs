using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using WordCounter.Rest.WordCounterApi.DataContracts.Base;

namespace WordCounter.Rest.WordCounterApi.DataContracts.Commands
{
    public class FileCommand : Request
    {
        [DataMember(Name = "content")]
        public Stream Content { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
