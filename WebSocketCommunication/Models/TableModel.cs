using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSocketCommunication.Models
{
    public class TableModel
    {
        private int RowsAmount { get; set; }
        private int ColsAmount { get; set; }
        private static Random random = new Random();

        public TableModel(int rows, int cols)
        {
            RowsAmount = rows;
            ColsAmount = cols;
        }

        public List<List<string>> GenerateTable()
        {
            var table = new List<List<string>>();
            for (int i = 0; i < RowsAmount; i++)
            {
                table.Add(GenerateRow(i));
            }
            return table;
        }

        private List<string> GenerateRow(int id)
        {
            var row = new List<string>();
            row.Add(id.ToString());
            for (int i = 1; i < ColsAmount; i++)
            {
                row.Add(RandomString(10));
            }
            return row;
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(1, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }

        private class Table
        {
            private TableRow Row { get; set; }
        }
        private class TableRow
        {
            private int RowID { get; set; }
            public string Col { get; set; }
        }
    }
}
