using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects
{
    /// <summary>
    /// Class that represents the row of a table of the SQLite result.
    /// </summary>
    public class SQLiteDBReadRow : IEnumerable<SQLiteDBReadColumn>
    {
        #region ===== FIELDS =====
        /// <summary>
        /// Index of the row.
        /// </summary>
        private int _Index = -1;

        /// <summary>
        /// Column of the row.
        /// </summary>
        private List<SQLiteDBReadColumn>? _Columns = null;
        #endregion

        #region ===== PROPERTIES =====
        /// <summary>
        /// Row number of the table.
        /// </summary>
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

        /// <summary>
        /// Columns of the row.
        /// </summary>
        private List<SQLiteDBReadColumn>? Columns
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
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new class <see cref="SQLiteDBReadRow"/>.
        /// </summary>
        /// <param name="index">Index number of the row.</param>
        public SQLiteDBReadRow(int index)
        {
            Index = index;
            Columns = new List<SQLiteDBReadColumn>(0);
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Add a new column of this row.
        /// </summary>
        /// <param name="column">Column to add.</param>
        public void AddColumn(SQLiteDBReadColumn column)
        {
            Columns?.Add(column);
        }

        /// <summary>
        /// Add a new column of this row.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="value">Content of the cell.</param>
        public void AddColumn(string columnName, object value)
        {
            AddColumn(new SQLiteDBReadColumn(columnName, value));
        }

        /// <summary>
        /// Retrieve the column from this row given the column name.
        /// </summary>
        /// <param name="columnName">Name of the column to get.</param>
        /// <returns>The column of this row.</returns>
        public SQLiteDBReadColumn? GetColumn(string columnName)
        {
            return Columns?.Where(c => c.Name == columnName).FirstOrDefault();
        }

        /// <summary>
        /// Get the value of the column of this row given the column name.
        /// </summary>
        /// <param name="columnName">Column name where get data.</param>
        /// <returns>The value of the cell of the column of this row.</returns>
        public object? GetColumnValue(string columnName)
        {
            return GetColumn(columnName)?.Value;
        }

        public IEnumerator<SQLiteDBReadColumn> GetEnumerator()
        {
            return Columns?.GetEnumerator() ?? default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region ===== OPERATORS =====
        /// <summary>
        /// Get the value of the column of this row given the column name.
        /// </summary>
        /// <param name="columnName">Column name where get data.</param>
        /// <returns>The value of the cell of the column of this row.</returns>
        public object? this[string columnName] => GetColumnValue(columnName); 
        #endregion
    }
}
