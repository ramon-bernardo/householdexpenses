using AutoMapper;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.People.Commands;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Application.People.Repositories;
using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Application.People.CommandHandlers;

public sealed class UpdatePersonCommandHandler(
    IPersonRepository personRepository,
    IMapper mapper
) : ICommandHandler<UpdatePersonCommand, PersonDTO>
{
    private readonly IPersonRepository PersonRepository = personRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<PersonDTO> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await PersonRepository.GetActiveById(request.Id);
        if (person is null)
        {
            throw new DomainException.NotFound("Person not found.");
        }

        person.Update(request.Name, request.Age);

        await PersonRepository.Update(person);

        return Mapper.Map<PersonDTO>(person);
    }
}
