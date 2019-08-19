using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace WebSocketCommunication.Models
{  
    public class Table
    {
        private static readonly Random Random = new Random();

        protected Table() { }

        public static DataTable GenerateTable(int rows)
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("stringColumn", typeof(string));
            table.Columns.Add("date", typeof(DateTime));

            for (var i = 0; i < rows; i++)
            {
                table.Rows.Add(i, RandomString(15), DateTime.Now);
            }

            return table;
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(1, length).Select(_ => chars[Random.Next(chars.Length)]).ToArray());
        }
    }
}