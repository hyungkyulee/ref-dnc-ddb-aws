using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Repositories
{
  public class ExpenseRepository : IExpenseRepository
  {
    /* // ---------- Object Persistence Model */
    private const string TableName = "DndExpensesDev";
    private readonly Table _table;

    public ExpenseRepository(IAmazonDynamoDB dynamoDbClient)
    {
      _table = Table.LoadTable(dynamoDbClient, TableName);
    }

    public async Task<IEnumerable<Document>> GetAllItems()
    {
      var config = new ScanOperationConfig();
      return await _table.Scan(config).GetRemainingAsync();
    }
    
    /* // ---------- Object Persistence Model 
    private readonly DynamoDBContext _context;
    public ExpenseRepository(IAmazonDynamoDB dynamoDbClient)
    {
      _context = new DynamoDBContext(dynamoDbClient);
    }
    
    public async Task<IEnumerable<ExpenseDb>> GetAllItems()
    {
      return await _context.ScanAsync<ExpenseDb>(new List<ScanCondition>()).GetRemainingAsync();
    }
    ----------------- */
  }
}