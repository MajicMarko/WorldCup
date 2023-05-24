using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static DAL.Model.Settings;

namespace DAL.Repositroy
{
    public class FileSettingsRepo : ISettingsRepo
    {
        private static readonly string DIR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\WorldCup\\temp";
        private static readonly string PATH = DIR + "\\settings.txt";
        private static readonly string PATH2 = DIR + "\\players.txt";

        public FileSettingsRepo()
        {
            CreateFilesIfNonExistent();
            CreateFilesForPlayersIfNonExistent();
        }

        private void CreateFilesIfNonExistent()
        {
            Directory.CreateDirectory(DIR);
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        private void CreateFilesForPlayersIfNonExistent()
        {
            Directory.CreateDirectory(DIR);
            if (!File.Exists(PATH2))
            {
                File.Create(PATH2).Close();
            }
        }

        public Settings LoadFavoritePlayers()
        {
            Settings settings = new Settings();
            string[] lines = File.ReadAllLines(PATH2);
            IList<Player> players = new List<Player>();
            settings.FavoritePlayers = new List<Player>();


            if (lines.Length!=0)
            {
                settings.FavoriteRepresentation = Team.ParseFromFile(lines[0]);
                for (int i = 1; i < lines.Length; i++)
                {
                    players.Add(Player.ParseFromFileLine(lines[i]));
                }
                players.ToList().ForEach(p => settings.FavoritePlayers.Add(p));
            }



            return settings;
        }

        public Settings LoadSettings()
        {
            Settings settings = new Settings();
            string[] lines = File.ReadAllLines(PATH);
 

            settings.Championship = (ChampionshipE)Enum.Parse(typeof(ChampionshipE), lines[0]);
            settings.Language = (LanguageE)Enum.Parse(typeof(LanguageE), lines[1]);
            settings.Size = (WindowSizeE)Enum.Parse(typeof(WindowSizeE), lines[2]);

            return settings;
        }

        public void SaveSettings(Settings settings)
        {
            IList<string> lines = new List<string>
            {
                settings.Championship.ToString(),
                settings.Language.ToString(),
                settings.Size.ToString(),
            };

            File.WriteAllLines(PATH, lines.ToArray());
        }
        public void SaveFavoritePlayers(Settings settings)
        {
            IList<string> lines = new List<string>
            {
                settings.FavoriteRepresentation.ParseForFileLine()
            };
            foreach (Player player in settings.FavoritePlayers)
            {
                lines.Add(player.ParseForFileLine());
            }
            File.WriteAllLines(PATH2, lines.ToArray());
        }

        public bool ExistingSettings()
        {
            string[] lines = File.ReadAllLines(PATH);

            if (lines.Length >= 3)
            {
                return true;
            }

            return false;
        }
        public bool ExistingPlayers()
        {
            string[] lines = File.ReadAllLines(PATH2);

            if (lines.Length >= 4)
            {
                return true;
            }

            return false;
        }
    }
}
