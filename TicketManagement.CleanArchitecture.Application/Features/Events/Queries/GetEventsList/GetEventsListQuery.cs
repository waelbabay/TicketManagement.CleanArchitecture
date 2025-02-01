using MediatR;

namespace TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList
{
    internal class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
