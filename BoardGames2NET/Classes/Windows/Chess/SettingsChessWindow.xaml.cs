using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BoardGames2NET.Classes.Windows.Chess
{
    /// <summary>
    /// Logica di interazione per SettingsChess.xaml
    /// </summary>
    public partial class SettingsChessWindow : Window
    {
        /// <summary>
        /// Initialize a new window.
        /// </summary>
        public SettingsChessWindow()
        {
            InitializeComponent();
        }

        private void SettingsChessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
        }

        /// <summary>
        /// Translate title of the window and all controls in.
        /// </summary>
        private void Translate()
        {
            Title = App.cRegions.GetTranslation("SETTINGS_CHESS_WINDOW_TITLE");
            App.cRegions.TranslateAllElementsInWindow(this);
        }

        /// <summary>
        /// Set the actual tab page.
        /// </summary>
        /// <param name="tab">Tab page to show.</param>
        private void SetTabPage(TabItem tab)
        {
            SettingsChessTabControl.SelectedItem = tab;
        }

        /// <summary>
        /// Manage the event <see cref="System.Windows.Controls.Primitives.ButtonBase.Click"/> of the button <see cref="HotSeatTranslatableButton"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes the event.<br/>This must be the button <see cref="HotSeatTranslatableButton"/>.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void HotSeatTranslatableButton_Click(object sender, RoutedEventArgs e)
        {
            SetTabPage(SettingsHotSeatPageTabItem);
        }

        /// <summary>
        /// Manage the event <see cref="System.Windows.Controls.Primitives.ButtonBase.Click"/> of the button <see cref="HotSeatCancelButton"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes the event.<br/>This must be the button <see cref="HotSeatCancelButton"/>.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void HotSeatCancelButton_Click(object sender, RoutedEventArgs e)
        {
            SetTabPage(SettingsMainPageTabItem);
        }

        /// <summary>
        /// Manage the event <see cref="System.Windows.Controls.Primitives.ButtonBase.Click"/> of the button <see cref="HotSeatPlayButton"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes the event.<br/>This must be the button <see cref="HotSeatPlayButton"/>.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void HotSeatPlayButton_Click(object sender, RoutedEventArgs e)
        {
            string wtsPlayerName = WhitesPlayerNameTextBox.Text;
            string bksPlayerName = BlacksPlayerNameTextBox.Text;

            #region Pre check that all names are inserted

            bool ok = CheckHotSeatNames(wtsPlayerName, bksPlayerName, out bool whiteOk, out bool blackOk);
            WarnMissingNamesColoringBackgroundsHotSeat(whiteOk, blackOk, Brushes.Yellow);

            if (!ok)
            {
                App.cRegions.ShowTranslatedMessageBox("NAME_MISSING_MSG_CONTENT", "NAME_MISSING_MSG_TITLE", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            #endregion Pre check that all names are inserted

            else //if ok
            {
                //Open window
            }
        }

        /// <summary>
        /// Check if names on fields are correctly inserted.<br/>
        /// This will check if the field is emty or with white spaces.
        /// </summary>
        /// <param name="whitesPlayerName">Name of the whites player.</param>
        /// <param name="blacksPlayerName">Name of the blacks player.</param>
        /// <param name="whitesPlayerOK">(<see langword="out"/>) <see langword="true"/> if the whites player name is correctly inserted, otherwise <see langword="false"/>.</param>
        /// <param name="blacksPlayerOK">(<see langword="out"/>) <see langword="true"/> if the blacks player name is correctly inserted, otherwise <see langword="false"/>.</param>
        /// <returns><see langword="false"/> if at least one of the two names are wrongly inserted, otherwise <see langword="true"/>.</returns>
        private bool CheckHotSeatNames(string whitesPlayerName, string blacksPlayerName, out bool whitesPlayerOK, out bool blacksPlayerOK)
        {
            whitesPlayerOK = !string.IsNullOrWhiteSpace(whitesPlayerName);
            blacksPlayerOK = !string.IsNullOrWhiteSpace(blacksPlayerName);

            return whitesPlayerOK && blacksPlayerOK;
        }

        /// <summary>
        /// Set background color the fields <see cref="WhitesPlayerNameTextBox"/> and <see cref="BlacksPlayerNameTextBox"/>.<br/>
        /// This method uses boolean values passed as parameters, if you pass <see langword="false"/> the background of the field changes.
        /// </summary>
        /// <param name="whitesOk"><see langword="true"/> if whites player name is ok, otherwise <see langword="false"/>.</param>
        /// <param name="blacksOk"><see langword="true"/> if whites blacks name is ok, otherwise <see langword="false"/>.</param>
        /// <param name="warnColor">Color of the background of the field in case the content is not ok.</param>
        private void WarnMissingNamesColoringBackgroundsHotSeat(bool whitesOk, bool blacksOk, SolidColorBrush warnColor)
        {
            WhitesPlayerNameTextBox.Background = whitesOk ? Brushes.Transparent : warnColor;
            BlacksPlayerNameTextBox.Background = blacksOk ? Brushes.Transparent : warnColor;
        }
    }
}