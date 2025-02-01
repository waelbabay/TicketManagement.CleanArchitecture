﻿using FluentValidation.Results;

namespace TicketManagement.CleanArchitecture.Application.Exceptions
{
    internal class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
    }
}
