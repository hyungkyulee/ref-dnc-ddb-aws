using System.Threading.Tasks;

namespace DexpensysDev.Services
{
  public interface ISetupService
  {
    Task CreateDynamoDbTable(string dynamoDbTableName);

    Task DeleteDynamoDbTable(string dynamoDbTableName);
  }
}