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
        private string _DatabasePath = null;

        public string DatabasePath
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

        private string ConnectionString => string.Format("Data Source={0}", DatabasePath);

        public Database(string sqliteDatabasePath)
        {
            DatabasePath = sqliteDatabasePath;
        }

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

    }
}
