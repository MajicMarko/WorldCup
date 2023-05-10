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
        private static readonly string DIR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"/temp";
        private static readonly string PATH = DIR + "/settings.txt";

        public FileSettingsRepo()
        {
            CreateFilesIfNonExistent();
        }

        private void CreateFilesIfNonExistent()
        {
            Directory.CreateDirectory(DIR);
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public Settings LoadSettings()
        {
            Settings settings = new Settings();
            string[] lines = File.ReadAllLines(PATH);
            IList<Player> players = new List<Player>();
            settings.FavoretePlayers = new List<Player>();

            settings.Championship = (ChampionshipE)Enum.Parse(typeof(ChampionshipE), lines[0]);
            settings.Language = (LanguageE)Enum.Parse(typeof(LanguageE), lines[1]);
            settings.Size = (WindowSizeE)Enum.Parse(typeof(WindowSizeE), lines[2]);

            settings.FavoreteRepresentation = Team.ParseFromFile(lines[3]);
            for (int i = 4; i < lines.Length; i++)
            {
                players.Add(Player.ParseFromFileLine(lines[i]));
            }
            players.ToList().ForEach(p => settings.FavoretePlayers.Add(p));

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
                settings.FavoreteRepresentation.ParseForFileLine()
            };
            foreach (Player player in settings.FavoretePlayers)
            {
                lines.Add(player.ParseForFileLine());
            }
            File.AppendAllLines(PATH, lines.ToArray());
        }

        public bool ExistingSettings()
        {
            string[] lines = File.ReadAllLines(PATH);

            if (lines.Length >= 7)
            {
                return true;
            }

            return false;
        }
    }
}
