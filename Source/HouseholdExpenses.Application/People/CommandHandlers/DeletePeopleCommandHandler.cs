using MediatR;
using HouseholdExpenses.Application.People.Commands;
using HouseholdExpenses.Application.People.Repositories;

namespace HouseholdExpenses.Application.People.CommandHandlers;

public sealed class DeletePersonCommandHandler(
    IPersonRepository personRepository
) : IRequestHandler<DeletePersonCommand, Unit>
{
    private readonly IPersonRepository PersonRepository = personRepository;

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await PersonRepository.GetActiveById(request.Id);
        if (person is null)
        {
            throw new Exception("Person not found."); // NotFoundException
        }

        person.Delete();

        await PersonRepository.Update(person);

        return Unit.Value;
    }
}
