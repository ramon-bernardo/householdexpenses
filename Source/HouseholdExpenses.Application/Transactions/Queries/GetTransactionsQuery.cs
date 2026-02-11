using MediatR;
using HouseholdExpenses.Application.Transactions.DTOs;

namespace HouseholdExpenses.Application.Transactions.Queries;

public sealed record GetTransactionsQuery : IRequest<IEnumerable<TransactionDTO>> { }
