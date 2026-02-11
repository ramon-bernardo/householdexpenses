using FluentValidation;
using HouseholdExpenses.Application.Transactions.Commands;

namespace HouseholdExpenses.Application.Transactions.Validators;

public sealed class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(400).WithMessage("Description max length is 400.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be a positive value.");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("A valid transaction type is required.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0u).WithMessage("A valid category is required.");

        RuleFor(x => x.PersonId)
            .GreaterThan(0u).WithMessage("A valid person is required.");
    }
}
