using System.Collections;

namespace BoardGames2NET.Classes.Objects
{
    /// <summary>
    /// Class that contains results retrieved from the SQLite database.
    /// </summary>
    public class SQLiteDBReadTable : IEnumerable<SQLiteDBReadRow>
    {
        /// <summary>
        /// Rows of the table.
        /// </summary>
        private List<SQLiteDBReadRow>? _Rows;

        /// <summary>
        /// Rows of the table.
        /// </summary>
        private List<SQLiteDBReadRow>? Rows
        {
            get
            {
                return _Rows;
            }
            set
            {
                if (value != null)
                {
                    if (!value.Equals(_Rows))
                    {
                        _Rows = value;
                    }
                }
                else
                {
                    _Rows = null;
                }
            }
        }

        /// <summary>
        /// Initialize a new <see cref="SQLiteDBReadTable"/> class.
        /// </summary>
        public SQLiteDBReadTable()
        {
            Rows = new List<SQLiteDBReadRow>(0);
        }

        /// <summary>
        /// Add a new row on the table.
        /// </summary>
        /// <param name="row">Row to add on the table.</param>
        public void AddRow(SQLiteDBReadRow row)
        {
            Rows?.Add(row);
        }

        /// <summary>
        /// Get row of the table with index <see cref="index"/>.
        /// </summary>
        /// <param name="index">Row number to get.</param>
        /// <returns>The row of the table of passed index.</returns>
        public SQLiteDBReadRow? GetRow(int index)
        {
            return Rows?.Where(r => r.Index.Equals(index)).FirstOrDefault();
        }

        /// <summary>
        /// Get the value of the cell of the table.
        /// </summary>
        /// <param name="index">Row number of the table.</param>
        /// <param name="columnName">Column name of the table.</param>
        /// <returns>The object contained into the cell.</returns>
        public object? GetValue(int index, string columnName)
        {
            return GetRow(index)?[columnName];
        }

        public IEnumerator<SQLiteDBReadRow> GetEnumerator()
        {
            return Rows?.GetEnumerator() ?? default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get row of the table with passed index.
        /// </summary>
        /// <param name="index">Row number to get.</param>
        /// <returns>The row of the table of passed index.</returns>
        public SQLiteDBReadRow? this[int index] => GetRow(index);
    }
}