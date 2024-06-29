using Domain.Enums;

namespace Domain.Entities
{
  public class TransactionFilter
  {

    public string? Search { get; set; }
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public TransactionType? TransactionType { get; set; }
    public DateTime? DueDate { get; set; }

  }
}
