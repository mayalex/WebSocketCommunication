
namespace WebSocketCommunication.Models
{
    public interface IDataRepository
    {
        Table GenerateTable(int rows, int cols);
    }
}