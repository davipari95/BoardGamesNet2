namespace BoardGames2NET.Classes.Objects
{
    /// <summary>
    /// Class that represents the column of a table of the SQLite result.
    /// </summary>
    public class SQLiteDBReadColumn
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string _Name = "";

        /// <summary>
        /// Value of the column.
        /// </summary>
        private object? _Value = null;

        /// <summary>
        /// Name of the column.
        /// </summary>
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

        /// <summary>
        /// Value of the column.
        /// </summary>
        public object? Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value != null)
                {
                    if (!value.Equals(_Value))
                    {
                        _Value = value;
                    }
                }
                else
                {
                    _Value = null;
                }
            }
        }

        /// <summary>
        /// Type of the value of the column.
        /// </summary>
        public Type? ValueType => Value?.GetType();

        /// <summary>
        /// Initialize a new class <see cref="SQLiteDBReadColumn"/>.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="value">Content of the cell of the column.</param>
        public SQLiteDBReadColumn(string columnName, object? value)
        {
            Name = columnName;
            Value = value;
        }
    }
}