using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Transactions.DTOs;
using HouseholdExpenses.Application.Transactions.Queries;
using HouseholdExpenses.Application.Transactions.Repositories;

namespace HouseholdExpenses.Application.Transactions.QueryHandlers;

public sealed class GetTransactionsQueryHandler(
    ITransactionRepository transactionRepository,
    IMapper mapper
) : IRequestHandler<GetTransactionsQuery, IEnumerable<TransactionDTO>>
{
    private readonly ITransactionRepository TransactionRepository = transactionRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<IEnumerable<TransactionDTO>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await TransactionRepository.GetAll();
        var mappedTransactions = Mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        return mappedTransactions;
    }
}
