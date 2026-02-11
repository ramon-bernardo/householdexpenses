using AutoMapper;
using HouseholdExpenses.Application.Categories.Repositories;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.People.Repositories;
using HouseholdExpenses.Application.Transactions.Commands;
using HouseholdExpenses.Application.Transactions.DTOs;
using HouseholdExpenses.Application.Transactions.Repositories;
using HouseholdExpenses.Domain.Common;
using HouseholdExpenses.Domain.Transactions.Entities;

namespace HouseholdExpenses.Application.Transactions.CommandHandlers;

public sealed class CreateTransactionCommandHandler(
    IPersonRepository personRepository,
    ICategoryRepository categoryRepository,
    ITransactionRepository transactionRepository,
    IMapper mapper
) : ICommandHandler<CreateTransactionCommand, TransactionDTO>
{
    private readonly IPersonRepository PersonRepository = personRepository;
    private readonly ICategoryRepository CategoryRepository = categoryRepository;
    private readonly ITransactionRepository TransactionRepository = transactionRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<TransactionDTO> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var person = await PersonRepository.GetActiveById(request.PersonId);
        if (person is null)
        {
            throw new DomainException.NotFound("Person not found.");
        }

        var category = await CategoryRepository.GetById(request.CategoryId);
        if (category is null)
        {
            throw new DomainException.NotFound("Category not found.");
        }

        var transaction = Transaction.Create(
            request.Description,
            request.Amount,
            request.Type,
            category,
            person
        );

        var persistedTransaction = await TransactionRepository.Add(transaction);

        return Mapper.Map<TransactionDTO>(persistedTransaction);
    }
}
