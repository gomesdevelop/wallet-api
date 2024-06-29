using System.Security.Claims;
using Domain.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
  [Route("transactions")]
  [ApiController]
  [Authorize]
  public class GetTransactionsController : ControllerBase
  {
    private readonly IGetTransactionsUseCase _getTransactionsUseCase;

    public GetTransactionsController(IGetTransactionsUseCase getTransactionsUseCase)
    {
      _getTransactionsUseCase = getTransactionsUseCase;
    }

    [HttpGet]
    public IActionResult GetTransactions([FromBody] TransactionFilterInput input)
    {
      Guid userId = new Guid(User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
      var filter = input.ToTransactionFilter();
      filter.UserId = userId;

      var result = _getTransactionsUseCase.GetAll(filter);

      return Ok(result.Result);
    }
  }
}
