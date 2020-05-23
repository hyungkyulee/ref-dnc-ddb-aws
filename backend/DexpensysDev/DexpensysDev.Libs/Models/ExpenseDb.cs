using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;

namespace DexpensysDev.Libs.Models
{
  [DynamoDBTable("DndExpensesDev")]
  public class ExpenseDb
  {
    [DynamoDBHashKey]
    public string UserId { get; set; }
    
    public string InvoiceKey { get; set; }
    
    public string InvoiceDate { get; set; }
    
    public string PaymentDate { get; set; }
    
    public string FinanceStatus { get; set; }

    public string CurrencyCode { get; set; }
    
    public int Amount { get; set; }
    
    public string InvoiceCategory { get; set; }
    
    public string BudgetType { get; set; }
    
    public string Remarks { get; set; }
  }
}