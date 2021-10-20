using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WordCounter.Contracts.ReadModels
{
    [Serializable]
    [DataContract]
    public class CountResult
    {
        [DataMember]
        public int TotalCount { get; set; }
    }
}
