using FluentValidation;
using HouseholdExpenses.Application.People.Commands;

namespace HouseholdExpenses.Application.People.Validators;

public sealed class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name max length is 200.");
    }
}
