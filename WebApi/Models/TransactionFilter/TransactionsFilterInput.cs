using Domain.Entities;
using Domain.Enums;

namespace WebApi.Models
{
  public class TransactionFilterInput
  {
    public string? Search { get; set; }
    public Guid? Id { get; set; }
    public TransactionType? TransactionType { get; set; }
    public DateTime? DueDate { get; set; }


    public TransactionFilterInput() { }

    public TransactionFilter ToTransactionFilter()
    {
      return new TransactionFilter
      {
        Search = Search,
        Id = Id,
        TransactionType = TransactionType,
        DueDate = DueDate
      };
    }
  }
}
