using MediatR;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Application.Transactions.Queries;
using HouseholdExpenses.Application.Transactions.Commands;
using HouseholdExpenses.Application.Transactions.DTOs;

namespace HouseholdExpenses.Api.Transactions.Controllers;

[ApiController]
[Route("api/transaction")]
[Produces("application/json")]
public sealed class TransactionController(ISender sender) : Controller
{
    private readonly ISender Sender = sender;

    [HttpPost]
    [ProducesResponseType(typeof(TransactionDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateTransactionCommand command)
    {
        var transaction = await Sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TransactionDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var transactions = await Sender.Send(new GetTransactionsQuery());
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TransactionDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(uint id)
    {
        var transaction = await Sender.Send(new GetTransactionByIdQuery(id));
        return Ok(transaction);
    }
}
