using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.Transactions.DTOs;
using HouseholdExpenses.Domain.Transactions.Enums;
using MediatR;

namespace HouseholdExpenses.Application.Transactions.Commands;

public sealed record CreateTransactionCommand(
    string Description,
    decimal Amount,
    TransactionType Type,
    uint CategoryId,
    uint PersonId
) : 
    ICommand<TransactionDTO>
{ }
