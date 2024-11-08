using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects
{
    public class SQLiteDBReadColumn
    {

        private string _Name = "";
        private object? _Value = null;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (!value.Equals(_Name))
                {
                    _Name = value;
                }
            }
        }

        public object? Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (!value.Equals(_Value))
                {
                    _Value = value;
                }
            }
        }

        public Type? ValueType => Value?.GetType();

        public SQLiteDBReadColumn(string columnName, object? value)
        {
            Name = columnName;
            Value = value;
        }

    }
}
