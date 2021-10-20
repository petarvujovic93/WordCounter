using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WordCounter.Rest.WordCounterApi.DataContracts.Models
{
    public class CountResult
    {
        [DataMember(Name = "total-count")]
        public int TotalCount { get; set; }
    }
}
