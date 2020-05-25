using System.Collections;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Mappers
{
  public interface IMapper
  {
    /* // ---------- Low-level Model */
    IEnumerable<ExpenseResponse> ToExpenseContract(ScanResponse response);
    ExpenseResponse ToExpenseContract(Dictionary<string, AttributeValue> item);
    ExpenseResponse ToExpenseContract(GetItemResponse response);

    /* // ---------- Document Model
    IEnumerable<ExpenseResponse> ToExpenseContract(IEnumerable<Document> items);
    ExpenseResponse ToExpenseContract(Document item);
    ----------------- */
  }
}