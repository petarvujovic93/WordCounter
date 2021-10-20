using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Business.Interface;
using WordCounter.Contracts.ReadModels;
using WordCounterService.CommandServices;

namespace WordCounterService.Handlers
{
    public class TextCommandHandler : IRequestHandler<TextCommandService, CountResult>
    {
        private readonly IWordCounter _wordCounter;
        public TextCommandHandler(IWordCounter wordCounter)
        {
            _wordCounter = wordCounter;
        }
        public Task<CountResult> Handle(TextCommandService request, CancellationToken cancellationToken)
        {
            var totalCount = _wordCounter.Count(request.TextCommand.Text);
            var result = new CountResult { TotalCount = totalCount };
            return Task.FromResult(result);
        }
    }
}
