namespace Topers.Core.Validators;

using Topers.Core.Dtos;
using FluentValidation;

public class GoodScopeDtoValidator : AbstractValidator<GoodScopeRequestDto>
{
    public GoodScopeDtoValidator()
    {
        RuleFor(g => g.GoodId)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
        RuleFor(g => g.Litre)
            .Must(IsLitreValid).WithMessage("Litre must be one of the following values: 1, 5, 10, 15, 25, 1000!");
        RuleFor(g => g.Price)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull();
    }

    private bool IsLitreValid(int litre)
    {
        int[] validLitres = { 1, 5, 10, 15, 25, 1000 };
        return validLitres.Contains(litre);
    }
}