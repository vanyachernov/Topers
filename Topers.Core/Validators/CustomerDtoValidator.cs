namespace Topers.Core.Validators;

using Topers.Core.Dtos;
using FluentValidation;

public class CustomerDtoValidator : AbstractValidator<CustomerRequestDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 60 characters!");
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .EmailAddress().WithMessage("A valid {PropertyName} is required!");
        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .Matches(@"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$").WithMessage("A valid {PropertyName} is required!");
    }
}