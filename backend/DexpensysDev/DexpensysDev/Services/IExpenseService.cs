using System.Collections.Generic;
using System.Threading.Tasks;
using DexpensysDev.Contracts;

namespace DexpensysDev.Services
{
  public interface IExpenseService
  {
    Task<IEnumerable<ExpenseResponse>> GetAllItemsFromDatabase();
    Task<ExpenseResponse> GetExpense(string userId, string invoiceKey);
  }
}