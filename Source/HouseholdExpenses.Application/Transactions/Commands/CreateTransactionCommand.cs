using MediatR;
using HouseholdExpenses.Application.Transactions.DTOs;
using HouseholdExpenses.Domain.Transactions.Enums;

namespace HouseholdExpenses.Application.Transactions.Commands;

public sealed record CreateTransactionCommand(
    string Description,
    decimal Amount,
    TransactionType Type,
    uint CategoryId,
    uint PersonId
) : IRequest<TransactionDTO>
{ }
