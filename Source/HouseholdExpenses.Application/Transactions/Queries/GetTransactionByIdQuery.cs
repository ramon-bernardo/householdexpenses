using MediatR;
using HouseholdExpenses.Application.Transactions.DTOs;

namespace HouseholdExpenses.Application.Transactions.Queries;

public sealed record GetTransactionByIdQuery(uint Id) : IRequest<TransactionDTO?> { }
