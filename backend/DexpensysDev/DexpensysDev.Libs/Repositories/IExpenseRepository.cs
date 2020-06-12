using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Repositories
{
  public interface IExpenseRepository
  {
    /* // ---------- Low-level Model */
    Task<ScanResponse> GetAllItems();
    Task<GetItemResponse> GetExpense(string userId, string invoiceKey);
    Task<QueryResponse> GetInvoiceDate(string invoiceKey);
    Task AddExpense(string userId, ExpenseDateRequest expenseDateRequest);
    Task UpdateExpense(string userId, ExpenseUpdateRequest updateRequest);

    /* // ---------- Document Model 
    Task<IEnumerable<Document>> GetAllItems();
    ----------------- */

    /* // ---------- Object Persistence Model
    Task<IEnumerable<ExpenseDb>> GetAllItems();
    ----------------- */
    Task CreateDynamoDbTable(string tableName);
  }
}