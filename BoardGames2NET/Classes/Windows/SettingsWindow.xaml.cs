using System.Windows;

namespace BoardGames2NET.Classes.Windows
{
    /// <summary>
    /// Logica di interazione per SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        /// <summary>
        /// Initialize a new window.
        /// </summary>
        public SettingsWindow()
        {
            InitializeComponent();

            LoadAvailableLanguagesComboBox();
        }

        /// <summary>
        /// Manage the event <see cref="FrameworkElement.Loaded"/> invoked by <see cref="SettingsWindow"/>.
        /// </summary>
        /// <param name="sender">Sender of the event.<br/>Represents <see langword="this"/> window.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
        }

        /// <summary>
        /// Translate title of this windows and all components in.
        /// </summary>
        private void Translate()
        {
            Title = App.cRegions.GetTranslation("SETTINGS");    //Translate title of the form
            App.cRegions.TranslateAllElementsInWindow(this);    //Translate all components
        }

        /// <summary>
        /// Load the elements in <see cref="ActiveLanguagesComboBox"/> from the dictionary stored in <see cref="Objects.App.Regions.AvailableLanguages"/>.
        /// </summary>
        private void LoadAvailableLanguagesComboBox()
        {
            ActiveLanguagesComboBox.ItemsSource = App.cRegions.AvailableLanguages;
            ActiveLanguagesComboBox.DisplayMemberPath = "Value";
            ActiveLanguagesComboBox.SelectedValuePath = "Key";

            ActiveLanguagesComboBox.SelectedValue = App.cSettings.ActiveLanguage;
        }

        /// <summary>
        /// Manage the event <see cref="System.Windows.Controls.Primitives.ButtonBase.Click"/> of the button <see cref="CancelTranslatableButton"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes this event.<br/>This should be the control <see cref="CancelTranslatableButton"/>.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void CancelTranslatableButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Manage the event <see cref="System.Windows.Controls.Primitives.ButtonBase.Click"/> of the button <see cref="SaveTranslatableButton"/>.
        /// </summary>
        /// <param name="sender">Sender that invokes this event.<br/>This should be the control <see cref="SaveTranslatableButton"/>.</param>
        /// <param name="e">State information and event data associated with a routed event.</param>
        private void SaveTranslatableButton_Click(object sender, RoutedEventArgs e)
        {
            #region Set language

            string newLanguage = Convert.ToString(ActiveLanguagesComboBox.SelectedValue) ?? "eng";
            App.cSettings.ActiveLanguage = newLanguage;

            #endregion Set language

            Close();
        }
    }
}