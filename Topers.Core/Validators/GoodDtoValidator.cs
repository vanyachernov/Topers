namespace Topers.Core.Validators;

using Topers.Core.Dtos;
using FluentValidation;

public class GoodDtoValidator : AbstractValidator<GoodRequestDto>
{
    public GoodDtoValidator()
    {
        RuleFor(g => g.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(120).WithMessage("{PropertyName} must not exceed 120 characters!");
    }
}