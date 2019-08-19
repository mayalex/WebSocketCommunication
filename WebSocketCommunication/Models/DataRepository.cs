﻿using System.Data;

namespace WebSocketCommunication.Models
{
    public class DataRepository : IDataRepository
    {
        private readonly DataTable _dataTable;
        public DataTable Data => _dataTable;
        public DataRepository()
        {
            if (_dataTable == null)
            {
                _dataTable = Table.GenerateTable(100);
            }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataRow Update(int id, DataRow row)
        {
            throw new System.NotImplementedException();
        }

        public DataRow Insert(DataRow row)
        {
            throw new System.NotImplementedException();
        }
    }
}