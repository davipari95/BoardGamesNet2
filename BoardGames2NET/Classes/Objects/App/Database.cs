using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.App
{
    public class Database
    {
        #region ===== FIELDS =====
        /// <summary>
        /// Path of the SQLite database.
        /// </summary>
        private string? _DatabasePath = null;
        #endregion

        #region ===== PROPERTIES =====
        /// <summary>
        /// Path of the SQLite database.
        /// </summary>
        public string? DatabasePath
        {
            get
            {
                return _DatabasePath;
            }
            private set
            {
                _DatabasePath = value;
            }
        }

        /// <summary>
        /// Connection string used for database connection.
        /// </summary>
        private string ConnectionString => string.Format("Data Source={0}", DatabasePath);
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new class <see cref="Database"/>.
        /// </summary>
        /// <param name="sqliteDatabasePath">Path of the SQLite file.</param>
        public Database(string sqliteDatabasePath)
        {
            DatabasePath = sqliteDatabasePath;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Execute a query and read the result parsing into a <see cref="SQLiteDBReadTable"/> variable.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <returns>A table containing the result of the query.</returns>
        public SQLiteDBReadTable ExecuteReaderQuery(string query)
        {
            SQLiteDBReadTable table = new SQLiteDBReadTable();

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = query;

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        for (int idx = 0; rdr.Read(); idx++)
                        {
                            SQLiteDBReadRow row = new SQLiteDBReadRow(idx);

                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                string colName = rdr.GetName(i);
                                object value = rdr[i];

                                row.AddColumn(colName, value);
                            }

                            table.AddRow(row);
                        }
                    }
                }
            }

            return table;
        }

        /// <summary>
        /// Execute a query without reading the result.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <returns>The number of affected rows.</returns>
        public int ExecuteQuery(string query)
        {
            int result = -1;

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = query;

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        } 
        #endregion
    }
}
