using System.Collections.Generic;
using System.Threading.Tasks;
using DexpensysDev.Contracts;
using DexpensysDev.Services;
using Microsoft.AspNetCore.Mvc;

namespace DexpensysDev.Controllers
{
  [Route("expenses")]
  public class ExpenseController : Controller
  {
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
      _expenseService = expenseService;
    }

    [HttpGet]
    public async Task<IEnumerable<ExpenseResponse>> GetAllItemsFromDatabase()
    {
      var results = await _expenseService.GetAllItemsFromDatabase();
      return results;
    }

    [HttpGet]
    [Route("{userId}/{invoiceKey}")]
    public async Task<ExpenseResponse> GetExpense(string userId, string invoiceKey)
    {
      var result = await _expenseService.GetExpense(userId, invoiceKey);
      return result;
    }

    [HttpGet]
    [Route("{InvoiceKey}/InvoiceDate")]
    public async Task<ExpenseDateResponse> GetInvoiceDate(string invoiceKey)
    {
      var result = await _expenseService.GetInvoiceDate(invoiceKey);
      return result;
    }

    [HttpPost]
    [Route("{userId}")]
    public async Task<IActionResult> AddExpense(string userId, [FromBody] ExpenseDateRequest request)
    {
      await _expenseService.AddExpense(userId, request);
      return Ok();
    }
    
    [HttpPatch]
    [Route("{userId}")]
    public async Task<IActionResult> UpdateExpense(string userId, [FromBody] ExpenseUpdateRequest request)
    {
      await _expenseService.UpdateExpense(userId, request);
      return Ok();
    }
  }
}