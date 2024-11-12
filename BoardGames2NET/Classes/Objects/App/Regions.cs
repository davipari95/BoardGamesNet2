using BoardGames2NET.Classes.CustomComponents;
using BoardGames2NET.Classes.StaticUtils;
using BoardGames2NET.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace BoardGames2NET.Classes.Objects.App
{
    /// <summary>
    /// Class that contains all regions method and utils for the application.
    /// </summary>
    public class Regions
    {
        #region ===== PROPERTIES =====
        /// <summary>
        /// All available languages for this application.<br/>
        /// The key is a three letter language (eng, ita, ...) while the value is the extended name (English, Italiano, ...).
        /// </summary>
        public Dictionary<string, string>? AvailableLanguages { get; private set; } = null;

        /// <summary>
        /// Translations used into this application.<br/>
        /// The first key is the ID of translation, while the second key is the three letters code of the language that you want to get the translation.
        /// </summary>
        private Dictionary<string, Dictionary<string, string>>? Translations { get; set; } = null;

        /// <summary>
        /// All available three letters codes of langauges for this application.
        /// </summary>
        private IEnumerable<string>? AvailableLanguagesCodes => AvailableLanguages?.Keys ?? null;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new class <see cref="Regions"/>.
        /// </summary>
        public Regions()
        {
            Initialize();
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Translate all <see cref="ITranslatable"/> controls inside a window into the language given in <paramref name="langCode"/>.
        /// </summary>
        /// <param name="window">The window where you want to translate controls.</param>
        /// <param name="langCode">Three letters language into which to translate the controls.</param>
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

        /// <summary>
        /// Translate all <see cref="ITranslatable"/> controls inside a window into the active language.
        /// </summary>
        /// <param name="window">The window where you want to translate controls.</param>
        public void TranslateAllElementsInWindow(Window window)
        {
            string langCode = BoardGames2NET.App.cSettings.ActiveLanguage;
            TranslateAllElementsInWindow(window, langCode);
        }

        /// <summary>
        /// Get the translation given a key passed in <paramref name="translationKey"/> and the language code given in <paramref name="langCode"/>.
        /// </summary>
        /// <param name="translationKey">Key of the translation.</param>
        /// <param name="langCode">Three letter language code into wich get the translation.</param>
        /// <returns>A string containing the translated text.</returns>
        /// <exception cref="NullReferenceException">Theown when the variable <see cref="Translations"/> is not initialized.</exception>
        public string GetTranslation(string translationKey, string langCode)
        {
            return Translations?[translationKey][langCode] ?? throw new NullReferenceException("Translsations table is not initialized.");
        }

        /// <summary>
        /// Get the translation given a key in <paramref name="translationKey"/> with the actual active language.
        /// </summary>
        /// <param name="translationKey">Key of the translation.</param>
        /// <returns>A string containing the translated text.</returns>
        public string GetTranslation(string translationKey)
        {
            string langCode = BoardGames2NET.App.cSettings.ActiveLanguage;
            return GetTranslation(translationKey, langCode);
        }

        /// <summary>
        /// Show a translated message box.
        /// </summary>
        /// <param name="messageKey">Translation key of the content of the message box.</param>
        /// <param name="titleKey">Translation key of the title of the message box.</param>
        /// <param name="buttons">Buttons to show into the message box.</param>
        /// <param name="image">Icon to show into the message box.</param>
        /// <returns>A dialog result with informations of the pressed button.</returns>
        public MessageBoxResult ShowTranslatedMessageBox(string messageKey, string titleKey, MessageBoxButton buttons, MessageBoxImage image)
        {
            string translatedMessage = GetTranslation(messageKey);
            string translatedTitle = GetTranslation(titleKey);

            return MessageBox.Show(translatedMessage, translatedTitle, buttons, image);
        }

        /// <summary>
        /// Show a translated message box.
        /// </summary>
        /// <param name="messageKey">Translation key of the content of the message box.</param>
        /// <param name="titleKey">Translation key of the title of the message box.</param>
        /// <param name="buttons">Buttons to show into the message box.</param>
        /// <returns>A dialog result with informations of the pressed button.</returns>
        public MessageBoxResult ShowTranslatedMessageBox(string messageKey, string titleKey, MessageBoxButton buttons)
        {
            return ShowTranslatedMessageBox(messageKey, titleKey, buttons, MessageBoxImage.None);
        }

        /// <summary>
        /// Show a translated message box.
        /// </summary>
        /// <param name="messageKey">Translation key of the content of the message box.</param>
        /// <param name="titleKey">Translation key of the title of the message box.</param>
        /// <returns>A dialog result with informations of the pressed button.</returns>
        public MessageBoxResult ShowTranslatedMessageBox(string messageKey, string titleKey)
        {
            return ShowTranslatedMessageBox(messageKey, titleKey, MessageBoxButton.OK, MessageBoxImage.None);
        }

        /// <summary>
        /// Initialize a new class.
        /// </summary>
        /// <exception cref="NullReferenceException">The variable <see cref="App.Database"/> is not initialized into the class <see cref="BoardGames2NET.App"/>.</exception>
        private void Initialize()
        {
            if (BoardGames2NET.App.cDatabase == null)
            {
                throw new NullReferenceException("Database class must be initialized before this class.");
            }

            LoadAvailableLangauges();
            LoadTranslations();
        }

        /// <summary>
        /// Load all available languages from database.
        /// </summary>
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

        /// <summary>
        /// Load all translations from database.
        /// </summary>
        /// <exception cref="NullReferenceException">The variable <see cref="AvailableLanguagesCodes"/> is not initialized or is null.</exception>
        private void LoadTranslations()
        {
            if (AvailableLanguagesCodes != null)
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
            else
            {
                throw new NullReferenceException("Variable \"AvailableLanguagesCodes\" cannot be null.");
            }
        } 
        #endregion

    }
}
