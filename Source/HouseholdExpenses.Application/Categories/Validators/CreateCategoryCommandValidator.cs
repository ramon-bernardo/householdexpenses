using FluentValidation;
using HouseholdExpenses.Application.Categories.Commands;

namespace HouseholdExpenses.Application.Categories.Validators;

public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(400).WithMessage("Description max length is 400.");

        RuleFor(x => x.Purpose)
            .IsInEnum()
            .WithMessage("Purpose is required and must be a valid enum value.");
    }
}
