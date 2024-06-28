using Dapper;
using Domain.Contracts.Repositories.AddTransaction;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Respositories.AddTransaction
{
  public class AddTransactionRepository : IAddTransactionRepository
  {
    private readonly IDbContext _dbContext;

    public AddTransactionRepository(IDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Add(Transaction transactions)
    {
      var query = $"INSERT INTO transactions (user_id, description, due_date, amount, transaction_type) VALUES (@userId, @description, @dueDate, @amount, @transactionType);";
      var parameters = new DynamicParameters();

      parameters.Add("userId", transactions.UserId, System.Data.DbType.Guid);
      parameters.Add("description", transactions.Description, System.Data.DbType.String);
      parameters.Add("dueDate", transactions.DueDate, System.Data.DbType.DateTime);
      parameters.Add("amount", transactions.Amount, System.Data.DbType.Double);
      parameters.Add("transactionType", transactions.TransactionType, System.Data.DbType.Int32);

      using var connection = _dbContext.CreateConnection();
      connection.Execute(query, parameters);
    }
  }
}