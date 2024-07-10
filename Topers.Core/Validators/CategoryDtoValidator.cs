namespace Topers.Core.Validators;

using Topers.Core.Dtos;
using FluentValidation;

public class CategoryDtoValidator : AbstractValidator<CategoryRequestDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(60).WithMessage("{PropertyName} must not exceed 60 characters!");
    }
}