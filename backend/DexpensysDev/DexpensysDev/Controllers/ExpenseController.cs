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
  }
}