namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Interface that contains informations for region translations.
    /// </summary>
    public interface ITranslatable
    {
        /// <summary>
        /// ID of the translation.
        /// </summary>
        public string LanguageKey { get; }

        /// <summary>
        /// This event is invoked when the value <see cref="LanguageKey"/> is changed.
        /// </summary>
        public event EventHandler<string> LanguageKeyChangedEvent;
    }
}