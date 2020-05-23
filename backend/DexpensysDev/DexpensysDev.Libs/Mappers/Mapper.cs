using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Mappers
{
  public class Mapper : IMapper
  {
    public IEnumerable<ExpenseResponse> ToExpenseContract(IEnumerable<ExpenseDb> items)
    {
      return items.Select(ToExpenseContract);
    }

    public ExpenseResponse ToExpenseContract(ExpenseDb expense)
    {
      return new ExpenseResponse
      {
        InvoiceKey = expense.InvoiceKey,
        PaymentDate = expense.PaymentDate,
        FinanceStatus = expense.FinanceStatus,
        CurrencyCode = expense.CurrencyCode,
        Amount = expense.Amount,
        InvoiceCategory = expense.InvoiceCategory,
        BudgetType = expense.BudgetType,
        Remarks = expense.Remarks
      };
    }
  }
}