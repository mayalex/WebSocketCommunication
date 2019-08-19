using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketCommunication.Models;

namespace WebSocketCommunication.Models
{
    public class DataRepository : IDataRepository
    {
        public Table GenerateTable(int rows, int cols)
        {
            var tableModel = new Table(10000, 3);
            return tableModel.GenerateTable();
        }
    }
}
