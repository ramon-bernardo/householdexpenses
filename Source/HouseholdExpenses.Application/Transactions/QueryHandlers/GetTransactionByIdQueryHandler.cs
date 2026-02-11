using AutoMapper;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.Transactions.DTOs;
using HouseholdExpenses.Application.Transactions.Queries;
using HouseholdExpenses.Application.Transactions.Repositories;
using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Application.Transactions.QueryHandlers;

public sealed class GetTransactionByIdQueryHandler(
    ITransactionRepository transactionRepository,
    IMapper mapper
) : ICommandHandler<GetTransactionByIdQuery, TransactionDTO>
{
    private readonly ITransactionRepository TransactionRepository = transactionRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<TransactionDTO> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await TransactionRepository.GetById(request.Id);
        if (transaction is null)
        {
            throw new DomainException.NotFound("Transaction not found.");
        }

        var mappedTransaction = Mapper.Map<TransactionDTO>(transaction);
        return mappedTransaction;
    }
}
