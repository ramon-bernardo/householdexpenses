using MediatR;
using HouseholdExpenses.Application.People.DTOs;

namespace HouseholdExpenses.Application.People.Queries;

public sealed record GetPersonByIdQuery(uint Id) : IRequest<PersonDTO?> { }
