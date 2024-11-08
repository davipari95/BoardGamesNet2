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
        public MainWindow()
        {
            InitializeComponent();

            App.cSettings.ActiveLanguageChangedEvent += CSettings_ActiveLanguageChangedEvent;
        }

        private void CSettings_ActiveLanguageChangedEvent(object? sender, string e)
        {
            Translate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow w = new SettingsWindow();
            w.ShowDialog();
        }

        private void Translate()
        {
            App.cRegions.TranslateAllElementsInWindow(this);
        }

        private void ChessTranslatableLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingsChessWindow window = new SettingsChessWindow();
            window.ShowDialog();
        }
    }
}