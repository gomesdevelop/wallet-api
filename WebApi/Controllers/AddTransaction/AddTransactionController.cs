using System.Security.Claims;
using Domain.Contracts.UseCases.AddTransaction;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.AddTransaction;
using WebApi.Models.Errors;
using WebApi.Models.UpdateTransaction;

namespace WebApi.Controllers
{
  [Route("transactions")]
  [ApiController]
  [Authorize]
  public class AddTransactionController : ControllerBase
  {
    private readonly IAddTransactionUseCase _addTransactionUseCase;
    private readonly IValidator<AddTransactionInput> _validator;

    public AddTransactionController(IAddTransactionUseCase addTransactionUseCase, IValidator<AddTransactionInput> validator)
    {
      _addTransactionUseCase = addTransactionUseCase;
      _validator = validator;
    }

    [HttpPost]
    public IActionResult AddTransaction([FromBody] AddTransactionInput input)
    {
      var validationResult = _validator.Validate(input);
      if (!validationResult.IsValid)
      {
        return BadRequest(validationResult.Errors.ToCustomValidationFailure());
      }

      Guid userId = new Guid(User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
      var transaction = new Transaction(userId, input.Description, input.DueDate, input.Amount, input.TransactionType);
      var result = _addTransactionUseCase.AddTransaction(transaction);

      return Created($"{Request.Path}/{transaction.Id}", result.Result);
    }

    // [HttpGet("{transactionId}")]
    // public IActionResult GetTransaction([FromQuery] Guid transactionId)
    // {
    //   Guid userId = new Guid(User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
    //   var filter = new TransactionFilter();
    //   filter.Id = transactionId;
    //   filter.UserId = userId;
    // 
    //   return Ok(filter);
    // }

    // [HttpGet]
    // public IActionResult GetTransactions([FromBody] TransactionFilterInput input)
    // {
    //   Guid userId = new Guid(User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
    //   var filter = input.ToTransactionFilter();
    //   filter.UserId = userId;
    // 
    //   return Ok(filter);
    // }

    // [HttpPatch("{transactionId}")]
    // public IActionResult UpdateTransaction([FromQuery] Guid transactionId, [FromBody] UpdateTransactionInput input)
    // {
    //   Guid userId = new Guid(User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
    //   var filter = new TransactionFilter();
    //   filter.Id = transactionId;
    //   filter.UserId = userId;
    // 
    //   return Ok(filter);
    // }

    // [HttpDelete("{transactionId}")]
    // public IActionResult DeleteTransaction([FromQuery] Guid transactionId)
    // {
    //   Guid userId = new Guid(User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
    //   var filter = new TransactionFilter();
    //   filter.Id = transactionId;
    //   filter.UserId = userId;
    // 
    //   return Ok(filter);
    // }

  }
}
