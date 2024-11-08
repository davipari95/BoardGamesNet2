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

namespace BoardGames2NET.Classes.Windows.Chess
{
    /// <summary>
    /// Logica di interazione per SettingsChess.xaml
    /// </summary>
    public partial class SettingsChessWindow : Window
    {
        public SettingsChessWindow()
        {
            InitializeComponent();
        }

        private void SettingsChessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
        }

        private void Translate()
        {
            Title = App.cRegions.GetTranslation("SETTINGS_CHESS_WINDOW_TITLE");
            App.cRegions.TranslateAllElementsInWindow(this);
        }

        private void HotSeatTranslatableButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
