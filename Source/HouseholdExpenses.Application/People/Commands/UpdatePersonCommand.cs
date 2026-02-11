using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.People.DTOs;

namespace HouseholdExpenses.Application.People.Commands;

public sealed record UpdatePersonCommand(
    uint Id,
    string Name,
    uint Age
) : 
    ICommand<PersonDTO>
{ }
