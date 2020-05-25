using System.Collections;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DocumentModel;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Models;

namespace DexpensysDev.Libs.Mappers
{
  public interface IMapper
  {
    IEnumerable<ExpenseResponse> ToExpenseContract(IEnumerable<Document> items);
    ExpenseResponse ToExpenseContract(Document item);
  }
}