using MediatR;
using HouseholdExpenses.Application.People.DTOs;

namespace HouseholdExpenses.Application.People.Commands;

public sealed record UpdatePersonCommand(
    uint Id,
    string Name,
    uint Age
) : IRequest<PersonDTO>
{ }
