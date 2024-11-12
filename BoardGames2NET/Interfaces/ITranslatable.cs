using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string LanguageKey { get; set; }

        /// <summary>
        /// This event is invoked when the value <see cref="LanguageKey"/> is changed.
        /// </summary>
        public event EventHandler<string> LanguageKeyChangedEvent;

    }
}
