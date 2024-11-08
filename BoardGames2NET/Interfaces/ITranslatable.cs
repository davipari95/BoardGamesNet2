using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Interfaces
{
    public interface ITranslatable
    {

        public string LanguageKey { get; set; }

        public event EventHandler<string> LanguageKeyChangedEvent;

    }
}
