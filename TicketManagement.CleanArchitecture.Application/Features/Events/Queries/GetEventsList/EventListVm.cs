﻿namespace TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Language { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}