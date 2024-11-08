using BoardGames2NET.Classes.Objects.App;
using System.Configuration;
using System.Data;
using System.Security.RightsManagement;
using System.Windows;

namespace BoardGames2NET
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        public static Database cDatabase = null;
        public static Regions cRegions = null;
        public static Settings cSettings = null;

        public App()
        {
            cDatabase = new Database("Data\\Data.db");
            cSettings = new Settings();
            cRegions = new Regions();
        }

    }

}
