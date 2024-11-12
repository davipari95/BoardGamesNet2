using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.App
{
    /// <summary>
    /// Class that contains the settings of the application.
    /// </summary>
    public class Settings
    {
        #region ===== FIELDS =====
        /// <summary>
        /// Actual activated language.<br/>
        /// Language uses a three letter code (ISO-639) (e.g. <tt>eng</tt>, <tt>ita</tt>, ...).
        /// </summary>
        private string _ActiveLanguage = "eng";
        #endregion

        #region ===== PROPERTIES =====
        /// <summary>
        /// Actual activated language.<br/>
        /// Language uses a three letter code (ISO-639) (e.g. <tt>eng</tt>, <tt>ita</tt>, ...).
        /// </summary>
        public string ActiveLanguage
        {
            get
            {
                return _ActiveLanguage;
            }
            set
            {
                if (value != _ActiveLanguage)
                {
                    _ActiveLanguage = value;
                    ActiveLanguageChangedEvent?.Invoke(this, value);
                }
            }
        }
        #endregion

        #region ===== EVENTS =====
        /// <summary>
        /// Event that is thrown every time the active language is changed.
        /// </summary>
        public event EventHandler<string> ActiveLanguageChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new class <see cref="Settings"/>.
        /// </summary>
        /// <exception cref="NullReferenceException">The class <see cref="Database"/> is not initialized yet in <see cref="BoardGames2NET.App"/> class.</exception>
        public Settings()
        {
            if (BoardGames2NET.App.cDatabase == null)
            {
                throw new NullReferenceException("Database class must be initialized before this class");
            }

            Load();

            ActiveLanguageChangedEvent += Settings_ActiveLanguageChangedEvent;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Manage the event <see cref="ActiveLanguageChangedEvent"/>.
        /// </summary>
        /// <param name="sender">Actual instance of the settings class.</param>
        /// <param name="e">New language code stored on variable <see cref="ActiveLanguage"/>.</param>
        private void Settings_ActiveLanguageChangedEvent(object? sender, string e)
        {
            StoreLanguageOnDB(e);
        }

        /// <summary>
        /// Store the language given in <paramref name="language"/> on database.
        /// </summary>
        /// <param name="language">Three code language to store in database.</param>
        /// <returns>The number of affected rows.</returns>
        private int StoreLanguageOnDB(string language)
        {
            return StoreSettingOnDB("ActiveLanguage", language);
        }

        /// <summary>
        /// Store the actual active language (stored in <see cref="ActiveLanguage"/>) on database.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        private int StoreLanguageOnDB()
        {
            return StoreLanguageOnDB(ActiveLanguage);
        }

        /// <summary>
        /// Store the value on settings table on database.
        /// </summary>
        /// <param name="columnName">Name of the column of database table.</param>
        /// <param name="value">Value to store into the database.</param>
        /// <returns>The number of affected rows.</returns>
        private int StoreSettingOnDB(string columnName, object value)
        {
            string valueString = value is string ? $"'{value}'" : $"{value}";

            string query = string.Format("UPDATE Settings SET {0}={1}", columnName, valueString);

            return BoardGames2NET.App.cDatabase.ExecuteQuery(query);
        }

        /// <summary>
        /// Load all settings from database.
        /// </summary>
        public void Load()
        {
            string query = "SELECT * FROM Settings";
            SQLiteDBReadTable dbResult = BoardGames2NET.App.cDatabase.ExecuteReaderQuery(query);

            string? activeLanguage = Convert.ToString(dbResult?[0]?["ActiveLanguage"]);

            if (activeLanguage != null)
            {
                _ActiveLanguage = activeLanguage;
            }
        }
        #endregion

    }
}
