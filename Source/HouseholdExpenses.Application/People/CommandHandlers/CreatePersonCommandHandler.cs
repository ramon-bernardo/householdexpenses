using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.People.Commands;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Application.People.Repositories;
using HouseholdExpenses.Domain.People.Entities;

namespace HouseholdExpenses.Application.People.CommandHandlers;

public sealed class CreatePersonCommandHandler(
    IPersonRepository personRepository,
    IMapper mapper
) : IRequestHandler<CreatePersonCommand, PersonDTO>
{
    private readonly IPersonRepository PersonRepository = personRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<PersonDTO> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = Person.Create(request.Name, request.Age);

        var persistedPerson = await PersonRepository.Add(person);

        return Mapper.Map<PersonDTO>(persistedPerson);
    }
}
