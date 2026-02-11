using MediatR;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Application.Categories.Commands;
using HouseholdExpenses.Application.Categories.Queries;
using HouseholdExpenses.Application.Categories.DTOs;

namespace HouseholdExpenses.Api.Categories.Controllers;

[ApiController]
[Route("api/category")]
[Produces("application/json")]
public sealed class CategoryController(ISender sender) : Controller
{
    private readonly ISender Sender = sender;

    [HttpPost]
    [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var category = await Sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var categories = await Sender.Send(new GetCategoriesQuery());
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
