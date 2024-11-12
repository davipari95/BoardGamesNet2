using BoardGames2NET.Classes.Windows;
using BoardGames2NET.Classes.Windows.Chess;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGames2NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            App.cSettings.ActiveLanguageChangedEvent += CSettings_ActiveLanguageChangedEvent;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Manage the event <see cref="Classes.Objects.App.Settings.ActiveLanguageChangedEvent"/>
        /// </summary>
        /// <param name="sender">Sender that invokes the event.<br/>This will be the actual instance of the class <see cref="Classes.Objects.App.Settings"/>.</param>
        /// <param name="e">New stored value of the variable <see cref="Classes.Objects.App.Settings.ActiveLanguage"/> that represents the actual selected language.</param>
        private void CSettings_ActiveLanguageChangedEvent(object? sender, string e)
        {
            Translate();
        }

        /// <summary>
        /// Manage the event <see cref="FrameworkElement.Loaded"/> invoked by <see cref="MainWindow"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes the event.<br/>It should be the window <see cref="MainWindow"/>.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
        }

        /// <summary>
        /// Manage the event <see cref="System.Windows.Controls.Primitives.ButtonBase.Click"/> of the button <see cref="SettingsButton"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes the event.<br/>This must be the button <see cref="SettingsButton"/>.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow w = new SettingsWindow();
            w.ShowDialog();
        }

        /// <summary>
        /// Translate all elements inside this window.
        /// </summary>
        private void Translate()
        {
            App.cRegions.TranslateAllElementsInWindow(this);
        }

        /// <summary>
        /// Manage the event <see cref="Control.MouseDoubleClick"/> of the list box item <see cref="ChessTranslatableListBoxItem"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes the event.<br/>This bust be the item <see cref="ChessTranslatableListBoxItem"/>.</param>
        /// <param name="e">Data for mouse button related event.</param>
        private void ChessTranslatableListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SettingsChessWindow window = new SettingsChessWindow();
            window.ShowDialog();
        }
        #endregion
    }
}