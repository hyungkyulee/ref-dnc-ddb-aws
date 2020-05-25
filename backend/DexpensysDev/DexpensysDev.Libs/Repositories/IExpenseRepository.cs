using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Repositories
{
  public interface IExpenseRepository
  {
    /* // ---------- Low-level Model */
    Task<ScanResponse> GetAllItems();
    Task<GetItemResponse> GetExpense(string userId, string invoiceKey);

    /* // ---------- Document Model 
    Task<IEnumerable<Document>> GetAllItems();
    ----------------- */

    /* // ---------- Object Persistence Model
    Task<IEnumerable<ExpenseDb>> GetAllItems();
    ----------------- */
  }
}