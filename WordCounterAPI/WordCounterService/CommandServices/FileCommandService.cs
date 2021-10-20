using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WordCounter.Contracts.Commands;
using WordCounter.Contracts.ReadModels;

namespace WordCounterService.CommandServices
{
    public class FileCommandService : IRequest<CountResult>
    {
        public FileCommandService(Document document)
        {
            Document = document;
        }

        public Document Document { get; set; }
    }
}
