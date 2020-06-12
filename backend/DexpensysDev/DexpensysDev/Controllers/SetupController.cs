using System.Threading.Tasks;
using DexpensysDev.Services;
using Microsoft.AspNetCore.Mvc;

namespace DexpensysDev.Controllers
{
  [Route("Setup")]
  public class SetupController : Controller
  {
    private readonly ISetupService _setupService;

    public SetupController(ISetupService setupService)
    {
      _setupService = setupService;
    }

    [HttpPost]
    [Route("createtable/{dynamoDbTableName}")]
    public async Task<IActionResult> CreateDynamoDbTable(string dynamoDbTableName)
    {
      await _setupService.CreateDynamoDbTable(dynamoDbTableName);
      return Ok();
    }
  }
}