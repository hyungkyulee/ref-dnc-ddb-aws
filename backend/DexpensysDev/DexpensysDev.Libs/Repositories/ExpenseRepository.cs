using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Repositories
{
  public class ExpenseRepository : IExpenseRepository
  {
    private readonly DynamoDBContext _context;
    public ExpenseRepository(IAmazonDynamoDB dynamoDbClient)
    {
      _context = new DynamoDBContext(dynamoDbClient);
    }

    public async Task<IEnumerable<ExpenseDb>> GetAllItems()
    {
      return await _context.ScanAsync<ExpenseDb>(new List<ScanCondition>()).GetRemainingAsync();
    }
  }
}