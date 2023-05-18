using DAL.Interface;
using DAL.Repositroy;
using System.Collections.Generic;

namespace DAL.Model
{
    public class Settings
    {
        public string Female = "https://worldcup.sfg.io";
        public string Male = "https://world-cup-json-2018.herokuapp.com";
        private ISettingsRepo settingsRepo;
        public enum ChampionshipE
        {
            Men,
            Women
        }

        public enum LanguageE
        {
            hr,
            en
        }

        public enum WindowSizeE
        {
            Small,
            Midium,
            Maximize
        }

        public ChampionshipE Championship { get; set; }

        public bool Exists()
        {
            settingsRepo = RepoFactory.GetSettingsRepo();
            bool existingSettings = settingsRepo.ExistingSettings();

            if (existingSettings)
            {
                return true;
            }

            return false;
        }

        public Settings Load()
        {
            return settingsRepo.LoadFavoritePlayers();
        }

        public LanguageE Language { get; set; }
        public WindowSizeE Size { get; set; }
        public Team FavoriteRepresentation { get; set; }
        public IList<Player> FavoritePlayers { get; set; }


        public void Save(Settings settings)
        {
            settingsRepo = RepoFactory.GetSettingsRepo();
            settingsRepo.SaveSettings(settings);
        }

        public void SavePlayers(Settings settings)
        {
            settingsRepo = RepoFactory.GetSettingsRepo();
            settingsRepo.SaveFavoritePlayers(settings);
        }
    }
}
