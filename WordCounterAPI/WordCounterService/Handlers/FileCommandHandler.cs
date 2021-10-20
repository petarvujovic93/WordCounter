using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Business;
using WordCounter.Business.Interface;
using WordCounter.Contracts.Commands;
using WordCounter.Contracts.ReadModels;
using WordCounter.Extensions.Configuration;
using WordCounter.Extensions.Exceptions;
using WordCounterService.CommandServices;

namespace WordCounterService.Handlers
{
    public class FileCommandHandler : IRequestHandler<FileCommandService, CountResult>
    {
        public readonly IMediator _mediator;
        public FileCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<CountResult> Handle(FileCommandService request, CancellationToken cancellationToken)
        {
            ValidateDocument(request.Document);
            var fileReader = FileReaderFactory.GetInstance(request.Document.Extension);
            var text = fileReader.Read(request.Document.Content);

            return await _mediator.Send(new TextCommandService(new TextCommand { Text = text }));
        }

        private void ValidateDocument(Document doc)
        {
            var allowedExtensions = ApiConfiguration.GetConfigurationList("AllowedFileExtensions");
            if ((doc?.Size ?? 0) == 0)
                throw new ValidationProblemException(new ValidationProblem ("Document is required", "Document"));
            else if (!allowedExtensions.Contains(doc.Extension))
                throw new ValidationProblemException(new ValidationProblem("Unallowed format", "Document"));
        }
        
    }
}
