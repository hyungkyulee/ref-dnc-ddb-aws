using System.Collections.Generic;
using System.Threading.Tasks;
using DexpensysDev.Contracts;

namespace DexpensysDev.Services
{
  public interface IExpenseService
  {
    Task<IEnumerable<ExpenseResponse>> GetAllItemsFromDatabase();
    Task<ExpenseResponse> GetExpense(string userId, string invoiceKey);
    Task<ExpenseDateResponse> GetInvoiceDate(string invoiceKey);
    
    Task AddExpense(string userId, ExpenseDateRequest expenseDateRequest);

    Task UpdateExpense(string userId, ExpenseUpdateRequest updateRequest);
  }
}