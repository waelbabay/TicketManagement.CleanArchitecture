using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.CleanArchitecture.Application.Features.Events.Commands.CreateEvent;
using TicketManagement.CleanArchitecture.Application.Features.Events.Commands.DetectEventReviewLanguage;
using TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList;

namespace TicketManagement.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            return await _mediator.Send(new GetEventsListQuery());
        }

        [HttpGet("{id}",Name ="GetEventById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id)
        {
            GetEventDetailQuery query = new GetEventDetailQuery() { EventId = id };
            return await _mediator.Send(query);
        }

        [HttpPost(Name = "CreateEvent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateEvent(CreateEventCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("reviewlanguage", Name = "DetectEventReviewLanguage")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<string>> DetectEventReviewLanguage([FromBody] DetectEventReviewLanguageCommand detectEventReviewLanguageCommand)
        {
            return await _mediator.Send(detectEventReviewLanguageCommand);
        }
    }
}
