using Domain.Enums;

namespace WebApi.Models.UpdateTransaction
{
  public class UpdateTransactionInput
  {
    public String Description { get; set; } = String.Empty;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public double Amount { get; set; } = 0;
    public TransactionType TransactionType { get; set; } = TransactionType.Debit;
  }
}
