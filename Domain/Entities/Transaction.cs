using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities
{
  public class Transaction
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; } = Guid.Empty;
    public String Description { get; set; } = String.Empty;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public double Amount { get; set; } = 0;
    public TransactionType TransactionType { get; set; } = TransactionType.Debit;

    public Transaction() { }

    public Transaction(Guid id, Guid userId, String description, DateTime dueDate, double amount, TransactionType transactionType)
    {
      Id = id;
      UserId = userId;
      Description = description;
      DueDate = dueDate;
      Amount = amount;
      TransactionType = transactionType;
    }

    public Transaction(Guid userId, String description, DateTime dueDate, double amount, TransactionType transactionType)
    {
      UserId = userId;
      Description = description;
      DueDate = dueDate;
      Amount = amount;
      TransactionType = transactionType;
    }
  }
}
