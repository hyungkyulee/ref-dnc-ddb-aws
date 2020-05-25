using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DocumentModel;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Mappers
{
  public class Mapper : IMapper
  {
    public IEnumerable<ExpenseResponse> ToExpenseContract(IEnumerable<Document> items)
    {
      return items.Select(ToExpenseContract);
    }

    public ExpenseResponse ToExpenseContract(Document item)
    {
      return new ExpenseResponse
      {
        InvoiceKey = item["InvoiceKey"],
        PaymentDate = item["PaymentDate"],
        FinanceStatus = item["FinanceStatus"],
        CurrencyCode = item["CurrencyCode"],
        Amount = (int) item["Amount"],
        InvoiceCategory = item["InvoiceCategory"],
        BudgetType = item["BudgetType"],
        Remarks = item["Remarks"]
      };
    }
  }
}