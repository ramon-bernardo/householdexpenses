using HouseholdExpenses.Application.Common;
using MediatR;

namespace HouseholdExpenses.Application.People.Commands;

public sealed record DeletePersonCommand(uint Id) :
    ICommand<Unit>
{ }
