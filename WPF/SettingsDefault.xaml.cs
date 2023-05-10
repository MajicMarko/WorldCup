using DAL.Interface;
using DAL.Model;
using DAL.Repositroy;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for SettingsDefault.xaml
    /// </summary>
    public partial class SettingsDefault : Window
    {
        private static IRepo repo;
        private static Settings settings;
        private static IImageRepo images;
        private Settings.LanguageE language;
        private static bool edit;

        public SettingsDefault()
        {
            repo = RepoFactory.GetRepo();
            settings = new Settings();
            images = RepoFactory.GetImageRepo();
            if (settings.Exists() && !edit)
            {
                settings = settings.Load();
                repo.Settings(settings);
                language = settings.Language;
                OpenNextForm(settings);
            }
            language = Settings.LanguageE.en;
            SetCulture();
        }

        private void SetCulture()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.ToString());
        }

        public SettingsDefault(bool editing)
        {
            edit = editing;
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedChampionship = (ComboBoxItem)ddlChampionship.SelectedItem;
            settings.Championship = (Settings.ChampionshipE)Enum.Parse(typeof(Settings.ChampionshipE), selectedChampionship.Name);
            ComboBoxItem selectedLanguage = (ComboBoxItem)ddlLanguage.SelectedItem;
            settings.Language = (Settings.LanguageE)Enum.Parse(typeof(Settings.LanguageE), selectedLanguage.Name);
            ComboBoxItem selectedSize = (ComboBoxItem)ddlSize.SelectedItem;
            settings.Size = (Settings.WindowSizeE)Enum.Parse(typeof(Settings.WindowSizeE), selectedSize.Name);

            OpenNextForm(settings);
        }

        private void OpenNextForm(Settings settings)
        {
            MainWindow mainWindow = new MainWindow(repo, settings);
            mainWindow.Settings(this, images);
            mainWindow.Show();
            this.Hide();
        }

        private void ddlLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedLanguage = (ComboBoxItem)ddlLanguage.SelectedItem;
            language = (Settings.LanguageE)Enum.Parse(typeof(Settings.LanguageE), selectedLanguage.Name);
            SetCulture();
        }
    }
}
