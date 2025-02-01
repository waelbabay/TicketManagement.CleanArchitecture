using FluentValidation.Results;
using TicketManagement.CleanArchitecture.Application.Responses;

namespace TicketManagement.CleanArchitecture.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse(bool success, string message) : base(success, message)
        {
        }

        public CreateCategoryCommandResponse(List<ValidationFailure> validationFailures) : base(validationFailures)
        {
        }

        public CreateCategoryCommandResponse(CategoryDto category) : base()
        {
            Category = category;
        }

        public CategoryDto? Category { get; set; }
    }
}