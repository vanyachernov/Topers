namespace Topers.Core.Validators;

using Topers.Core.Dtos;
using FluentValidation;

public class OrderDtoValidator : AbstractValidator<OrderRequestDto>
{
    public OrderDtoValidator()
    {
        RuleFor(o => o.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
        RuleFor(o => o.Date)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
        RuleFor(o => o.TotalPrice)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
    }
}