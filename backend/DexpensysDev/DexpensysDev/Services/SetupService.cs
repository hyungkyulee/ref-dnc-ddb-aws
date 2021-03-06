using System.Threading.Tasks;
using DexpensysDev.Libs.Repositories;

namespace DexpensysDev.Services
{
  public class SetupService : ISetupService
  {
    private readonly IExpenseRepository _expenseRepository;

    public SetupService(IExpenseRepository expenseRepository)
    {
      _expenseRepository = expenseRepository;
    }

    public async Task CreateDynamoDbTable(string dynamoDbTableName)
    {
      await _expenseRepository.CreateDynamoDbTable(dynamoDbTableName);
    }

    public async Task DeleteDynamoDbTable(string dynamoDbTableName)
    {
      await _expenseRepository.DeleteDynamoDbTable(dynamoDbTableName);
    }
  }
}