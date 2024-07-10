namespace Topers.Core.Validators;

using Topers.Core.Dtos;
using FluentValidation;
using System.Data;

public class OrderDetailsDtoValidator : AbstractValidator<OrderDetailsRequestDto>
{
    public OrderDetailsDtoValidator()
    {
        RuleFor(d => d.OrderId)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
        RuleFor(d => d.GoodId)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
        RuleFor(d => d.Quantity)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .GreaterThan(0).WithMessage("A product {PropertyName} must be greater than 0!");
        RuleFor(d => d.Price)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
    }
}