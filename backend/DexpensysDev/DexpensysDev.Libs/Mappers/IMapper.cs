using System.Collections;
using System.Collections.Generic;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Mappers
{
  public interface IMapper
  {
    IEnumerable<ExpenseResponse> ToExpenseContract(IEnumerable<ExpenseDb> items);
    ExpenseResponse ToExpenseContract(ExpenseDb expense);
  }
}