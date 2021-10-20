using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.DataAccess;
using WordCounter.DataAccess.Repositories;
using WordCounter.Contracts.Commands;
using WordCounterService.CommandServices;
using WordCounter.Contracts.ReadModels;

namespace WordCounterService.Handlers
{
    public class DBCommandHandler : IRequestHandler<DBCommandService, CountResult>
    {
        private readonly IMediator _mediator;
        private readonly DataAccess dataAccess;

        public DBCommandHandler(IMediator mediator, ITextRepository textRepository)
        {
            _mediator = mediator;
            dataAccess = new DataAccess(textRepository);
        }

        public async Task<CountResult> Handle(DBCommandService request, CancellationToken cancellationToken)
        {
            var textFromDB = dataAccess.GetText();
            var textCommand = new TextCommand
            {
                Text = textFromDB
            };

            return await _mediator.Send(new TextCommandService(textCommand));
        }
    }
}
