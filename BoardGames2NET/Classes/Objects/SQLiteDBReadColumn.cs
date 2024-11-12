using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects
{
    /// <summary>
    /// Class that represents the column of a table of the SQLite result.
    /// </summary>
    public class SQLiteDBReadColumn
    {

        #region ===== FIELDS =====
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string _Name = "";

        /// <summary>
        /// Value of the column.
        /// </summary>
        private object? _Value = null;
        #endregion

        #region ===== PROPERTIES =====
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
        #endregion

        #region ===== CONSTRUCTORS =====
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
        #endregion

    }
}
