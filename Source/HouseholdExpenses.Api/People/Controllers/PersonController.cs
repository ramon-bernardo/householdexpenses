using MediatR;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Application.People.Commands;
using HouseholdExpenses.Application.People.Queries;

namespace HouseholdExpenses.Api.People.Controllers;

[ApiController]
[Route("api/person")]
public sealed class PersonController(ISender sender) : Controller
{
    private readonly ISender Sender = sender;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonCommand command)
    {
        var person = await Sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] uint id, [FromBody] UpdatePersonCommand command)
    {
        command = command with { Id = id };
        var person = await Sender.Send(command);
        return Ok(person);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(uint id)
    {
        await Sender.Send(new DeletePersonCommand(id));
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var people = await Sender.Send(new GetPeopleQuery());
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(uint id)
    {
        var person = await Sender.Send(new GetPersonByIdQuery(id));
        return Ok(person);
    }
}
