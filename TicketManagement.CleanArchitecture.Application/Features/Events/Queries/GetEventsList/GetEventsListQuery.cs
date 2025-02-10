using MediatR;

namespace TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
