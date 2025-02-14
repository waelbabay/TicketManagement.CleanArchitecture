﻿using AutoMapper;
using FluentValidation.Results;
using MediatR;
using TicketManagement.CleanArchitecture.Application.Contracts.Infrastructure;
using TicketManagement.CleanArchitecture.Application.Contracts.Persistence;
using TicketManagement.CleanArchitecture.Application.Exceptions;
using TicketManagement.CleanArchitecture.Domain.Entities;

namespace TicketManagement.CleanArchitecture.Application.Features.Events.Commands.CreateEvent
{
    internal class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILanguageDetector _languageDetector;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, ILanguageDetector languageDetector)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _languageDetector = languageDetector;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            CreateEventCommandValidator validator = new CreateEventCommandValidator(_eventRepository);
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            Event @event = _mapper.Map<Event>(request);
            @event.Language = await _languageDetector.DetectLanguage(request.Description);

            @event = await _eventRepository.AddAsync(@event);

            return @event.EventId;
        }
    }
}
