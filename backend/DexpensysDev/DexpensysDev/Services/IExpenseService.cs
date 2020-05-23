using System.Collections.Generic;
using System.Threading.Tasks;
using DexpensysDev.Contracts;

namespace DexpensysDev.Services
{
  public interface IExpenseService
  {
    Task<IEnumerable<ExpensesResponse>> GetAllItemsFromDatabase();
  }
}