using DAL.Interface;
using DAL.Model;
using DAL.Repositroy;

namespace WorldCup
{
    internal static class Program
    {

        private static IRepo repo;
        private static Settings settings;
        private static IImageRepo images;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            repo = RepoFactory.GetRepo();
            settings = new Settings();
            images = RepoFactory.GetImageRepo();
            if (settings.Exists())
            {
                settings = settings.Load();
                repo.Settings(settings);
                FavoritePlayers favoritePlayers = new(repo, settings, images);
                RangList rangList = new RangList(repo, settings, images);
                favoritePlayers.Show();
                Application.Run(favoritePlayers);
            }
            else
            {
                Menu menu = new Menu(repo);
                menu.SettingsLoad(settings, images);
                Application.Run(menu);
            }
        }
    }
}