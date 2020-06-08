using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DexpensysDev.Contracts;
using DexpensysDev.Libs.Mappers;
using DexpensysDev.Libs.Repositories;

namespace DexpensysDev.Services
{
  public class ExpenseService : IExpenseService
  {
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;

    public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
    {
      _expenseRepository = expenseRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ExpenseResponse>> GetAllItemsFromDatabase()
    {
      var response = await _expenseRepository.GetAllItems();
      return _mapper.ToExpenseContract(response);
    }
    
    public async Task<ExpenseResponse> GetExpense(string userId, string invoiceKey)
    {
      var response = await _expenseRepository.GetExpense(userId, invoiceKey);
      return _mapper.ToExpenseContract(response);
    }

    public async Task AddExpense(string userId, ExpenseDateRequest expenseDateRequest)
    {
      await _expenseRepository.AddExpense(userId, expenseDateRequest);
    }
    
    // public async Task UpdateExpense(string userId, ExpenseUpdateRequest updateRequest)
    // {
    //   await _expenseRepository.UpdateExpense(userId, updateRequest);
    // }
  }
}