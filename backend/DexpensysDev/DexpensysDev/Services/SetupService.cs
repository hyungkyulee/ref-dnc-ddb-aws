using System.Threading.Tasks;
using DexpensysDev.Libs.Repositories;

namespace DexpensysDev.Services
{
  public class SetupService
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
  }
}