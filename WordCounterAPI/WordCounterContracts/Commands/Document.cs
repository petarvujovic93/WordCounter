using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace WordCounter.Contracts.Commands
{
    public class Document
    {
        public string Name { get; set; }
        public long Size { get; set; } 
        public string Extension { get; set; }
        public Stream Content { get; set; }
    }
}
