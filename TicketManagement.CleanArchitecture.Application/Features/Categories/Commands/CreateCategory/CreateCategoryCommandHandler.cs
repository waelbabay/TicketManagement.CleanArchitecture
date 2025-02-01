using AutoMapper;
using FluentValidation.Results;
using MediatR;
using TicketManagement.CleanArchitecture.Application.Contracts.Persistence;
using TicketManagement.CleanArchitecture.Domain.Entities;

namespace TicketManagement.CleanArchitecture.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();

            ValidationResult validation = await validator.ValidateAsync(request);

            if (validation.Errors.Count > 0)
            {
                return new CreateCategoryCommandResponse(validation.Errors);  
            }
            else
            {
                Category category = _mapper.Map<Category>(request);
                category = await _categoryRepository.AddAsync(category);

                return new CreateCategoryCommandResponse(_mapper.Map<CategoryDto>(category));
            }
        }
    }
}
