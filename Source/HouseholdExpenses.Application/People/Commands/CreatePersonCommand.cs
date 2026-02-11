using MediatR;
using HouseholdExpenses.Application.People.DTOs;

namespace HouseholdExpenses.Application.People.Commands;

public sealed record CreatePersonCommand(
    string Name,
    uint Age
) : IRequest<PersonDTO>
{ }
