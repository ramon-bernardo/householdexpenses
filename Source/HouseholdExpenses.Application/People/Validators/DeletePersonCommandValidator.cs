using FluentValidation;
using HouseholdExpenses.Application.People.Commands;

namespace HouseholdExpenses.Application.People.Validators;

public sealed class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
{
    public DeletePersonCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0u)
            .WithMessage("Id must be greater than 0.");
    }
}
