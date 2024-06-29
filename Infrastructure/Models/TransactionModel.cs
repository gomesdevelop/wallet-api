using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Infrastructure;

[Table("transactions")]
public class TransactionModel
{
  [Column("id")]
  public Guid Id { get; set; }

  [Column("user_id")]
  public Guid UserId { get; set; } = Guid.Empty;

  [Column("description")]
  public String Description { get; set; } = String.Empty;

  [Column("due_date")]
  public DateTime DueDate { get; set; } = DateTime.Now;

  [Column("amount")]
  public double Amount { get; set; } = 0;

  [Column("transaction_type")]
  public TransactionType TransactionType { get; set; } = TransactionType.Debit;

  public TransactionModel(Guid userId, String description, DateTime dueDate, double amount, TransactionType transactionType)
  {
    UserId = userId;
    Description = description;
    DueDate = dueDate;
    Amount = amount;
    TransactionType = transactionType;
  }

}
