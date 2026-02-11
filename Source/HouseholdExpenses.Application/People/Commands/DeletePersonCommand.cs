using MediatR;

namespace HouseholdExpenses.Application.People.Commands;

public sealed record DeletePersonCommand(uint Id) : IRequest<Unit> { }
