using BoardGames2NET.Classes.CustomComponents;
using BoardGames2NET.Classes.StaticUtils;
using BoardGames2NET.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace BoardGames2NET.Classes.Objects.App
{
    public class Regions
    {
        public Dictionary<string, string> AvailableLanguages { get; private set; } = null;
        private Dictionary<string, Dictionary<string, string>> Translations { get; set; } = null;
        private IEnumerable<string> AvailableLanguagesCodes => AvailableLanguages.Keys;

        public Regions()
        {
            Initialize();
        }

        public void TranslateAllElementsInWindow(Window window, string langCode)
        {
            IEnumerable<ITranslatable>? translatableElements = UWindow.GetTranslatableChildren(window);

            if (translatableElements != null)
            {
                foreach (ITranslatable element in translatableElements)
                {
                    string lanKey = element.LanguageKey;

                    if (!string.IsNullOrWhiteSpace(lanKey))
                    {
                        if (element is HeaderedContentControl)
                        {
                            ((HeaderedContentControl)element).Header = GetTranslation(lanKey, langCode);
                        }
                        else if (element is ContentControl)
                        {
                            ((ContentControl)element).Content = GetTranslation(lanKey, langCode);
                        }
                    }
                }
            }
        }

        public void TranslateAllElementsInWindow(Window window)
        {
            string langCode = BoardGames2NET.App.cSettings.ActiveLanguage;
            TranslateAllElementsInWindow(window, langCode);
        }

        public string GetTranslation(string translationKey, string langCode)
        {
            return Translations[translationKey][langCode];
        }

        public string GetTranslation(string translationKey)
        {
            string langCode = BoardGames2NET.App.cSettings.ActiveLanguage;
            return GetTranslation(translationKey, langCode);
        }

        private void Initialize()
        {
            if (BoardGames2NET.App.cDatabase == null)
            {
                throw new NullReferenceException("Database class must be initialized before this class.");
            }

            LoadAvailableLangauges();
            LoadTranslations();
        }

        private void LoadAvailableLangauges()
        {
            AvailableLanguages = new Dictionary<string, string>(0);

            string query = "SELECT * FROM AvailableLanguages";

            SQLiteDBReadTable result = BoardGames2NET.App.cDatabase.ExecuteReaderQuery(query);

            foreach (SQLiteDBReadRow row in result)
            {
                string? lanCode = Convert.ToString(row["LanguageCode"]);
                string? description = Convert.ToString(row["Description"]);

                if (lanCode != null && description != null)
                {
                    AvailableLanguages.Add(lanCode, description);
                }
            }
        }

        private void LoadTranslations()
        {
            Translations = new Dictionary<string, Dictionary<string, string>>(0);

            string query = "SELECT * FROM Regions";

            SQLiteDBReadTable dbResult = BoardGames2NET.App.cDatabase.ExecuteReaderQuery(query);

            foreach (SQLiteDBReadRow row in dbResult)
            {
                string? translateKey = Convert.ToString(row["Key"]);
                Dictionary<string, string> translates = new Dictionary<string, string>(0);

                foreach (string lanCode in AvailableLanguagesCodes)
                {
                    string? translation = Convert.ToString(row[lanCode]);

                    if (translation != null)
                    {
                        translates.Add(lanCode, translation);
                    }
                }

                if (translateKey != null)
                {
                    Translations.Add(translateKey, translates);
                }
            }
        }

    }
}
