using AutoMapper;
using TicketManagement.CleanArchitecture.Application.Features.Categories.Commands.CreateCategory;
using TicketManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketManagement.CleanArchitecture.Application.Features.Events.Commands.CreateEvent;
using TicketManagement.CleanArchitecture.Application.Features.Events.Commands.UpdateEvent;
using TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList;
using TicketManagement.CleanArchitecture.Domain.Entities;

namespace TicketManagement.CleanArchitecture.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>();
            CreateMap<CreateEventCommand, Event>();
            CreateMap<UpdateEventCommand, Event>();


            CreateMap<Category, Features.Events.Queries.GetEventDetail.CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Category, Features.Categories.Commands.CreateCategory.CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
           

            
        }
    }
}
