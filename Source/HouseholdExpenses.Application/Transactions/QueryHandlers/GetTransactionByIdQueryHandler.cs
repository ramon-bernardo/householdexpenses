using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Transactions.Repositories;
using HouseholdExpenses.Application.Transactions.DTOs;
using HouseholdExpenses.Application.Transactions.Queries;

namespace HouseholdExpenses.Application.Transactions.QueryHandlers;

public sealed class GetTransactionByIdQueryHandler(
    ITransactionRepository transactionRepository,
    IMapper mapper
) : IRequestHandler<GetTransactionByIdQuery, TransactionDTO?>
{
    private readonly ITransactionRepository TransactionRepository = transactionRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<TransactionDTO?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await TransactionRepository.GetById(request.Id);
        var mappedTransaction = Mapper.Map<TransactionDTO>(transaction);
        return mappedTransaction;
    }
}
