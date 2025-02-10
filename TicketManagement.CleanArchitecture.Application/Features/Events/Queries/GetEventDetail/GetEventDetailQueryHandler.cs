using AutoMapper;
using MediatR;
using TicketManagement.CleanArchitecture.Application.Contracts.Persistence;
using TicketManagement.CleanArchitecture.Application.Exceptions;
using TicketManagement.CleanArchitecture.Domain.Entities;

namespace TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            Event? eventDetail = await _eventRepository.GetByIdAsync(request.EventId);

            if(eventDetail == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId.ToString());
            }

            return _mapper.Map<EventDetailVm>(eventDetail);
        }
    }
}
