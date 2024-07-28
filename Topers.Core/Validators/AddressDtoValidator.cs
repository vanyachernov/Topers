namespace Topers.Core.Validators;

using Topers.Core.Dtos;
using FluentValidation;

public class AddressDtoValidator : AbstractValidator<AddressRequestDto>
{
    public AddressDtoValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must not exceed 50 characters!");
        RuleFor(a => a.City)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(60).WithMessage("{PropertyName} must not exceed 50 characters!");
        RuleFor(a => a.State)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(60).WithMessage("{PropertyName} must not exceed 50 characters!");
        RuleFor(a => a.PostalCode)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MinimumLength(5).WithMessage("{PropertyName} must not be lower than 5 characters!")
            .MaximumLength(5).WithMessage("{PropertyName} must not exceed 5 characters!");
        RuleFor(a => a.Country)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(60).WithMessage("{PropertyName} must not exceed 50 characters!");
    }
}