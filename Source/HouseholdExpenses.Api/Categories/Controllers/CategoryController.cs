using MediatR;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Application.Categories.Commands;
using HouseholdExpenses.Application.Categories.Queries;
using HouseholdExpenses.Application.Categories.QueryHandlers;

namespace HouseholdExpenses.Api.Categories.Controllers;

[ApiController]
[Route("api/category")]
public sealed class CategoryController(ISender sender) : Controller
{
    private readonly ISender Sender = sender;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var category = await Sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await Sender.Send(new GetCategoriesQuery());
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(uint id)
    {
        var category = await Sender.Send(new GetCategoryByIdQuery(id));
        if (category is null)
        {
            return NotFound();
        }
        return Ok(category);
    }
}
