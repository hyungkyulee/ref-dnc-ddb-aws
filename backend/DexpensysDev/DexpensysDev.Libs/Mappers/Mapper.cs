using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Mappers
{
  public class Mapper : IMapper
  {
    public IEnumerable<ExpensesResponse> ToExpenseContract(IEnumerable<ExpenseDb> items)
    {
      return items.Select(ToExpenseContract);
    }

    public ExpensesResponse ToExpenseContract(ExpenseDb expense)
    {
      
    }
  }
}