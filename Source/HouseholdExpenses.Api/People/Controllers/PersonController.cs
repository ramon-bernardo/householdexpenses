using MediatR;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Application.People.Commands;
using HouseholdExpenses.Application.People.Queries;
using HouseholdExpenses.Application.People.DTOs;

namespace HouseholdExpenses.Api.People.Controllers;

[ApiController]
[Route("api/person")]
[Produces("application/json")]
public sealed class PersonController(ISender sender) : Controller
{
    private readonly ISender Sender = sender;

    [HttpPost]
    [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreatePersonCommand command)
    {
        var person = await Sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] uint id, [FromBody] UpdatePersonCommand command)
    {
        command = command with { Id = id };
        var person = await Sender.Send(command);
        return Ok(person);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove(uint id)
    {
        await Sender.Send(new DeletePersonCommand(id));
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PersonDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var people = await Sender.Send(new GetPeopleQuery());
        return Ok(people);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(uint id)
    {
        var person = await Sender.Send(new GetPersonByIdQuery(id));
        if (person is null)
        {
            return NotFound();
        }
        return Ok(person);
    }
}
