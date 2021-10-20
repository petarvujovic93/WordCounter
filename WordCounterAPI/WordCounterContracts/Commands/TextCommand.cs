using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace WordCounter.Contracts.Commands
{
    public class TextCommand
    {
        [Required]
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
