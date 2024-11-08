using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects
{
    public class SQLiteDBReadRow : IEnumerable<SQLiteDBReadColumn>
    {
        private int _Index = -1;
        private List<SQLiteDBReadColumn> _Columns = null;

        public int Index
        {
            get
            {
                return _Index;
            }
            set
            {
                if (!_Index.Equals(value))
                {
                    _Index = value;
                }
            }
        }

        private List<SQLiteDBReadColumn> Columns
        {
            get
            {
                return _Columns;
            }
            set
            {
                if (_Columns == null || !_Columns.Equals(value))
                {
                    _Columns = value;
                }
            }
        }

        public SQLiteDBReadRow(int index)
        {
            Index = index;
            Columns = new List<SQLiteDBReadColumn>(0);
        }

        public void AddColumn(SQLiteDBReadColumn column)
        {
            Columns.Add(column);
        }

        public void AddColumn(string columnName, object value)
        {
            AddColumn(new SQLiteDBReadColumn(columnName, value));
        }

        public SQLiteDBReadColumn? GetColumn(string columnName)
        {
            return Columns.Where(c => c.Name == columnName).FirstOrDefault();
        }

        public object? GetColumnValue(string columnName)
        {
            return GetColumn(columnName)?.Value;
        }

        public IEnumerator<SQLiteDBReadColumn> GetEnumerator()
        {
            return Columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object? this[string columnName] => GetColumnValue(columnName);
    }
}
