using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Mappers
{
  public class Mapper : IMapper
  {
    /* // ---------- Low-level Model */
    public IEnumerable<ExpenseResponse> ToExpenseContract(ScanResponse response)
    {
      return response.Items.Select(ToExpenseContract);
    }

    public ExpenseResponse ToExpenseContract(Dictionary<string, AttributeValue> item)
    {
      return new ExpenseResponse
      {
        InvoiceKey = item["InvoiceKey"].S,
        PaymentDate = item["PaymentDate"].S,
        FinanceStatus = item["FinanceStatus"].S,
        CurrencyCode = item["CurrencyCode"].S,
        Amount = Convert.ToInt32(item["Amount"].N),
        InvoiceCategory = item["InvoiceCategory"].S,
        BudgetType = item["BudgetType"].S,
        Remarks = item["Remarks"].S
      };
    }
    
    public ExpenseResponse ToExpenseContract(GetItemResponse response)
    {
      return new ExpenseResponse
      {
        InvoiceKey = response.Item["InvoiceKey"].S,
        PaymentDate = response.Item["PaymentDate"].S,
        FinanceStatus = response.Item["FinanceStatus"].S,
        CurrencyCode = response.Item["CurrencyCode"].S,
        Amount = Convert.ToInt32(response.Item["Amount"].N),
        InvoiceCategory = response.Item["InvoiceCategory"].S,
        BudgetType = response.Item["BudgetType"].S,
        Remarks = response.Item["Remarks"].S
      };
    }


    /* // ---------- Document Model 
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
    ----------------- */
  }
}