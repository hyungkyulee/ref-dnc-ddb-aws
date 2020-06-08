namespace DexpensysDev.Contracts
{
  public class ExpenseDateRequest
  {
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