using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Repositories
{
  public class ExpenseRepository : IExpenseRepository
  {
    /* // ---------- Low-level Model */
    private const string TableName = "DndExpensesDev";
    private readonly IAmazonDynamoDB _dynamoDbClient;

    public ExpenseRepository(IAmazonDynamoDB dynamoDbClient)
    {
      _dynamoDbClient = dynamoDbClient;
    }

    public async Task<ScanResponse> GetAllItems()
    {
      var scanRequest = new ScanRequest(TableName);
      return await _dynamoDbClient.ScanAsync(scanRequest);
    }

    public async Task<GetItemResponse> GetExpense(string userId, string invoiceKey)
    {
      var request = new GetItemRequest
      {
        TableName = TableName,
        Key = new Dictionary<string, AttributeValue>
        {
          {"UserId", new AttributeValue {S = userId}},
          {"InvoiceKey", new AttributeValue {S = invoiceKey}}
        }
      };
      return await _dynamoDbClient.GetItemAsync(request);
    }

    public async Task AddExpense(string userId, ExpenseDateRequest expenseDateRequest)
    {
      var request = new PutItemRequest
      {
        TableName = TableName,
        Item = new Dictionary<string, AttributeValue>
        {
          {"UserId", new AttributeValue {S = userId}},
          {"InvoiceKey", new AttributeValue {S = expenseDateRequest.InvoiceKey}},
          {"InvoiceDate", new AttributeValue {S = DateTime.UtcNow.ToString()}},
          {"PaymentDate", new AttributeValue {S = DateTime.UtcNow.ToString()}},
          {"FinanceStatus", new AttributeValue {S = expenseDateRequest.FinanceStatus}},
          {"CurrencyCode", new AttributeValue {S = expenseDateRequest.CurrencyCode}},
          {"Amount", new AttributeValue {N = expenseDateRequest.Amount.ToString()}},
          {"InvoiceCategory", new AttributeValue {S = expenseDateRequest.InvoiceCategory}},
          {"BudgetType", new AttributeValue {S = expenseDateRequest.BudgetType}},
          {"Remarks", new AttributeValue {S = expenseDateRequest.Remarks}},
        }
      };

      await _dynamoDbClient.PutItemAsync(request);
    }

    /* // ---------- Document Model 
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
    ----------------- */
    
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