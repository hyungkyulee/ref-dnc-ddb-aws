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
      _mapper = _mapper;
    }

    public async Task<IEnumerable<ExpenseResponse>> GetAllItemsFromDatabase()
    {
      var response = await _expenseRepository.GetAllItems();
      return _mapper.ToExpenseContract(response);
    }
  }
}