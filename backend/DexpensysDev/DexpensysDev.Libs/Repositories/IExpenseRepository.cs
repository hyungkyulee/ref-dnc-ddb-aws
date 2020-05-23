using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Repositories
{
  public interface IExpenseRepository
  {
    Task<IEnumerable<ExpenseDb>> GetAllItems();
  }
}