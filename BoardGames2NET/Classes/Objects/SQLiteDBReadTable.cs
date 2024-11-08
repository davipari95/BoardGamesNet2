using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects
{
    public class SQLiteDBReadTable : IEnumerable<SQLiteDBReadRow>
    {
        private List<SQLiteDBReadRow> _Rows;

        private List<SQLiteDBReadRow> Rows
        {
            get
            {
                return _Rows;
            }
            set
            {
                if (!value.Equals(_Rows))
                {
                    _Rows = value;
                }
            }
        }

        public SQLiteDBReadTable()
        {
            Rows = new List<SQLiteDBReadRow>(0);
        }

        public void AddRow(SQLiteDBReadRow row)
        {
            Rows.Add(row);
        }

        public SQLiteDBReadRow? GetRow(int index)
        {
            return Rows.Where(r => r.Index.Equals(index)).FirstOrDefault();
        }

        public object? GetValue(int index, string columnName)
        {
            return GetRow(index)?[columnName];
        }

        public IEnumerator<SQLiteDBReadRow> GetEnumerator()
        {
            return Rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SQLiteDBReadRow? this[int index] => GetRow(index);
    }
}
