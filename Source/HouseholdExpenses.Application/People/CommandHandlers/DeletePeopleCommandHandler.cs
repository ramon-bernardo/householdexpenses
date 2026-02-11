using MediatR;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.People.Commands;
using HouseholdExpenses.Application.People.Repositories;
using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Application.People.CommandHandlers;

public sealed class DeletePersonCommandHandler(
    IPersonRepository personRepository
) : ICommandHandler<DeletePersonCommand, Unit>
{
    private readonly IPersonRepository PersonRepository = personRepository;

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await PersonRepository.GetActiveById(request.Id);
        if (person is null)
        {
            throw new DomainException.NotFound("Person not found.");
        }

        person.Delete();

        await PersonRepository.Update(person);

        return Unit.Value;
    }
}
