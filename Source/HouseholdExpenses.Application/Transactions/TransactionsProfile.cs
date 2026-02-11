using AutoMapper;
using HouseholdExpenses.Application.Transactions.DTOs;
using HouseholdExpenses.Domain.Transactions.Entities;

namespace HouseholdExpenses.Application.Transactions;

public sealed class TransactionsProfile : Profile
{
    public TransactionsProfile()
    {
        CreateMap<Transaction, TransactionDTO>();
    }
}
