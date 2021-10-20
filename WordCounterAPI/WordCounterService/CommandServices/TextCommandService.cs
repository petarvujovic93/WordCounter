using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WordCounter.Contracts.Commands;
using WordCounter.Contracts.ReadModels;

namespace WordCounterService.CommandServices
{
    public class TextCommandService : IRequest<CountResult>
    {
        public TextCommandService (TextCommand textCommand)
        {
            TextCommand = textCommand;
        }
        public TextCommand TextCommand { get; set; }
    }
}
