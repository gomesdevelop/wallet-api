using System.Security.Claims;
using Domain.Contracts.UseCases.AddTransaction;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddTransaction;
using WebApi.Models.Errors;

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
      var customer = new Transaction(userId, input.Description, input.DueDate, input.Amount, input.TransactionType);
      _addTransactionUseCase.AddTransaction(customer);

      return Created("", customer);
    }

  }
}
