using MediatR;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Application.Transactions.Queries;
using HouseholdExpenses.Application.Transactions.Commands;

namespace HouseholdExpenses.Api.Transactions.Controllers;

[ApiController]
[Route("api/transaction")]
public sealed class TransactionController(ISender sender) : Controller
{
    private readonly ISender Sender = sender;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionCommand command)
    {
        var transaction = await Sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var transactions = await Sender.Send(new GetTransactionsQuery());
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(uint id)
    {
        var transaction = await Sender.Send(new GetTransactionByIdQuery(id));
        return Ok(transaction);
    }
}
