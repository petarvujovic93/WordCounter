using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WordCounter.Contracts.Commands;
using WordCounter.Contracts.ReadModels;
using WordCounter.Extensions.ModelBinders;
using WordCounterService.CommandServices;

namespace WordCounter.Controllers
{
    [ApiController]
    [Route("v1/word-counter")]
    public class WordCounterAPIController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WordCounterAPIController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("count")]
        public async Task<CountResult> Count(TextCommand textCommand)
        {
            return await _mediator.Send(new TextCommandService(textCommand));
        }

        [HttpPost]
        [Route("count-from-db")]
        [ProducesResponseType(typeof(CountResult), 200)]
        public async Task<CountResult> CountFromDB()
        {
            return await _mediator.Send(new DBCommandService());
        }

        [HttpPost]
        [Route("count-from-file")]
        public async Task<CountResult> CountFromFile([ModelBinder(typeof(DocumentsModelBinder))] Document document)
        {
            return await _mediator.Send(new FileCommandService(document));
        }
    }
}
