using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.App
{
    public class Settings
    {

        private string _ActiveLanguage = "eng";

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

        public event EventHandler<string> ActiveLanguageChangedEvent;

        public Settings()
        {
            if (BoardGames2NET.App.cDatabase == null)
            {
                throw new NullReferenceException("Database class must be initialized before this class");
            }

            LoadSettings();

            ActiveLanguageChangedEvent += Settings_ActiveLanguageChangedEvent;
        }

        private void Settings_ActiveLanguageChangedEvent(object? sender, string e)
        {
            StoreLanguageOnDB(e);
        }

        private int StoreLanguageOnDB(string language)
        {
            return StoreSettingOnDB("ActiveLanguage", language);
        }

        private int StoreLanguageOnDB()
        {
            return StoreLanguageOnDB(ActiveLanguage);
        }

        private int StoreSettingOnDB(string columnName, object value)
        {
            string valueString = value is string ? $"'{value}'" : $"{value}";

            string query = string.Format("UPDATE Settings SET {0}={1}", columnName, valueString);

            return BoardGames2NET.App.cDatabase.ExecuteQuery(query);
        }

        public void LoadSettings()
        {
            string query = "SELECT * FROM Settings";
            SQLiteDBReadTable dbResult = BoardGames2NET.App.cDatabase.ExecuteReaderQuery(query);

            string? activeLanguage = Convert.ToString(dbResult?[0]?["ActiveLanguage"]);

            if (activeLanguage != null)
            {
                _ActiveLanguage = activeLanguage;
            }
        }

    }
}
