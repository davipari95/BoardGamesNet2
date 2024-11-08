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
using System.Windows.Shapes;

namespace BoardGames2NET.Classes.Windows
{
    /// <summary>
    /// Logica di interazione per SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            LoadAvailableLanguagesComboBox();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
        }

        private void Translate()
        {
            Title = App.cRegions.GetTranslation("SETTINGS");    //Translate title of the form
            App.cRegions.TranslateAllElementsInWindow(this);    //Translate all components
        }

        private void LoadAvailableLanguagesComboBox()
        {
            ActiveLanguagesComboBox.ItemsSource = App.cRegions.AvailableLanguages;
            ActiveLanguagesComboBox.DisplayMemberPath = "Value";
            ActiveLanguagesComboBox.SelectedValuePath = "Key";

            ActiveLanguagesComboBox.SelectedValue = App.cSettings.ActiveLanguage;
        }

        private void CancelTranslatableButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveTranslatableButton_Click(object sender, RoutedEventArgs e)
        {
            #region Set language
            string newLanguage = Convert.ToString(ActiveLanguagesComboBox.SelectedValue) ?? "eng";
            App.cSettings.ActiveLanguage = newLanguage;
            #endregion

            Close();
        }
    }
}
