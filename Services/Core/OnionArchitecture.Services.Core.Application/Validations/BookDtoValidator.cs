using FluentValidation;
using OnionArchitecture.Services.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Application.Validations
{
    public class BookDtoValidator : AbstractValidator<BookDto>
    {

        public BookDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Price).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

            RuleFor(x => x.Stock).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }

    }
}
