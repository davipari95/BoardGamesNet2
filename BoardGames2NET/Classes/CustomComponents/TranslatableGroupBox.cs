using BoardGames2NET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGames2NET.Classes.CustomComponents
{
    /// <summary>
    /// Per utilizzare questo controllo personalizzato in un file XAML, eseguire i passaggi 1a o 1b e 2.
    ///
    /// Passaggio 1a) Utilizzo di questo controllo personalizzato in un file XAML esistente nel progetto corrente.
    /// Aggiungere questo attributo XmlNamespace all'elemento radice del file di markup dove 
    /// deve essere utilizzato:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BoardGames2NET.Classes.CustomComponents"
    ///
    ///
    /// Passaggio 1b) Utilizzo di questo controllo personalizzato in un file XAML esistente in un progetto diverso.
    /// Aggiungere questo attributo XmlNamespace all'elemento radice del file di markup dove 
    /// deve essere utilizzato:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BoardGames2NET.Classes.CustomComponents;assembly=BoardGames2NET.Classes.CustomComponents"
    ///
    /// Sarà inoltre necessario aggiungere nel progetto in cui si trova il file XAML
    /// un riferimento a questo progetto, quindi ricompilare per evitare errori di compilazione:
    ///
    ///     In Esplora soluzioni, fare clic con il pulsante destro del mouse sul progetto di destinazione, quindi scegliere
    ///     "Aggiungi riferimento"->"Progetti"->[Individuare e selezionare questo progetto]
    ///
    ///
    /// Passaggio 2)
    /// Utilizzare il controllo nel file XAML.
    ///
    ///     <MyNamespace:TranslatableGroupBox/>
    ///
    /// </summary>
    public class TranslatableGroupBox : GroupBox, ITranslatable
    {
        private string _LanguageKey = "";
        public string LanguageKey
        {
            get
            {
                return _LanguageKey;
            }
            set
            {
                if (value != _LanguageKey)
                {
                    _LanguageKey = value;
                    LanguageKeyChangedEvent?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<string> LanguageKeyChangedEvent;

        static TranslatableGroupBox()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(TranslatableGroupBox), new FrameworkPropertyMetadata(typeof(TranslatableGroupBox)));
        }
    }
}
