using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IRepo repo;
        private static IImageRepo images;
        private Settings.LanguageE language;
        private IList<Team> teams;
        private IList<Match> matches;
        private IList<Match> homeTeamMatches = new List<Match>();
        private static Settings settings;
        private Match match;
        private SettingsDefault settingsDefault;
        private bool editing;



        public MainWindow(IRepo repository, Settings mainSettings)
        {
            repo = repository;
            settings = mainSettings;
            repo.Settings(settings);
            language = settings.Language;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.ToString());

            //ode je bila greska jer je uzimalo 0 pogledaj i za medium ostale stvari rade
            if (settings.Size == DAL.Model.Settings.WindowSizeE.Small)
            {
                this.Height = 600;
                this.Width = 1000;
            }
            if (settings.Size == DAL.Model.Settings.WindowSizeE.Midium)
            {
                this.Height = 800;
                this.Width = 1200;
            }
            if (settings.Size == DAL.Model.Settings.WindowSizeE.Maximize)
            {
                this.WindowState = WindowState.Maximized;
            }

            InitializeComponent();

        }

        public void Settings(SettingsDefault defaultSettings, IImageRepo imagesRepo)
        {
            images = imagesRepo;
            settingsDefault = defaultSettings;
            PrepareData();
        }

        private async Task PrepareData()
        {
            lblError.Content = "Loading data...";
            lblError.Visibility = Visibility.Visible;
            sPError.Visibility = Visibility.Visible;
            btnAwayTeamDetails.IsEnabled = false;
            btnHomeTeamDetails.IsEnabled = false;
            try
            {
                matches = await repo.LoadMatches();
                teams = await repo.LoadTeams(settings);
            }
            catch (Exception)
            {
                lblError.Content = "Conntect costumer support.\nKontaktiraj korisničku službu.";
                lblError.Visibility = Visibility.Visible;
                sPError.Visibility = Visibility.Hidden;
            }
            teams.ToList().Sort();
            teams.ToList().ForEach(t => ddlHomeTeam.Items.Add(t));

            if (settings.FavoriteRepresentation != null || (ddlHomeTeam.SelectedItem = settings.FavoriteRepresentation) == null)
            {
                ddlHomeTeam.SelectedItem = settings.FavoriteRepresentation;
            }
            else
            {
                ddlHomeTeam.SelectedIndex = 0;
            }

            lblError.Visibility = Visibility.Hidden;
            sPError.Visibility = Visibility.Hidden;
            btnAwayTeamDetails.IsEnabled = true;
            btnHomeTeamDetails.IsEnabled = true;
        }

        private void LoadDdlAwayTeam()
        {
            foreach (Match match in matches)
            {
                if (match.HomeTeam.Equals(ddlHomeTeam.SelectedItem))
                {
                    ddlAgainstTeam.Items.Add(match.AwayTeam);
                    homeTeamMatches.Add(match);
                }
                if (match.AwayTeam.Equals(ddlHomeTeam.SelectedItem))
                {
                    ddlAgainstTeam.Items.Add(match.HomeTeam);
                    homeTeamMatches.Add(match);
                }
            }
            ddlAgainstTeam.SelectedIndex = 0;
        }

        private void OpenHomeTeam_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam = (Team)ddlHomeTeam.SelectedItem;

            TeamDetails team = new TeamDetails(repo);
            team.LoadData(selectedTeam);
            team.ShowDialog();
        }

        private void AwayHomeTeam_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam = (Team)ddlAgainstTeam.SelectedItem;

            TeamDetails team = new TeamDetails(repo);
            team.LoadData(selectedTeam);
            team.ShowDialog();
        }

        private void ddlHomeTeam_IndexChanged(object sender, SelectionChangedEventArgs e)
        {
            homeTeamMatches.Clear();
            ddlAgainstTeam.Items.Clear();
            LoadDdlAwayTeam();
        }

        private void ddlAwayTeam_IndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (homeTeamMatches.Count == 0)
            {
                return;
            }

            if (homeTeamMatches.FirstOrDefault(m => m.AwayTeam.Equals(ddlAgainstTeam.SelectedItem)) != null)
            {
                match = homeTeamMatches.FirstOrDefault(m => m.AwayTeam.Equals(ddlAgainstTeam.SelectedItem));
                LoadGoals(match.HomeTeam, match.AwayTeam);
                LoadField(match.HomeTeamStatistics, match.AwayTeamStatistics);
            }
            else
            {
                match = homeTeamMatches.FirstOrDefault(m => m.HomeTeam.Equals(ddlAgainstTeam.SelectedItem));
                LoadGoals(match.AwayTeam, match.HomeTeam);
                LoadField(match.AwayTeamStatistics, match.HomeTeamStatistics);
            }
            lblResult.Visibility = Visibility.Visible;
        }

        private void LoadField(TeamStatistics homeTeamStatistics, TeamStatistics awayTeamStatistics)
        {
            List<Player> homeEleven = homeTeamStatistics.StartingEleven;
            List<Player> awayEleven = awayTeamStatistics.StartingEleven;
            ResetField();
            LoadField(homeEleven, "home");
            LoadField(awayEleven, "away");
        }

        private void ResetField()
        {
            goalieColumn.Children.Clear();
            defendersColumn.Children.Clear();
            midfieldColumn.Children.Clear();
            forwardColumn.Children.Clear();
            awayGoalieColumn.Children.Clear();
            awayDefendersColumn.Children.Clear();
            awayMidfieldColumn.Children.Clear();
            awayForwardColumn.Children.Clear();
        }

        private void LoadField(List<Player> startingPlayers, string team)
        {
            PlayerUC goalie = new PlayerUC(images);
            goalie.LoadData(startingPlayers.Find(p => p.Position == Player.PositionE.Goalie));
            goalie.MouseDoubleClick += player_MouseDoubleClick;

            List<Player> defenders = new List<Player>();
            List<Player> midfields = new List<Player>();
            List<Player> forwards = new List<Player>();

            foreach (Player player in startingPlayers)
            {
                if (player.Position == Player.PositionE.Defender)
                {
                    defenders.Add(player);
                }
                else if (player.Position == Player.PositionE.Midfield)
                {
                    midfields.Add(player);
                }
                else if (player.Position == Player.PositionE.Forward)
                {
                    forwards.Add(player);
                }
            }

            if (team == "home")
            {
                goalieColumn.Children.Add(goalie);
                AddPlayersToColumn(defenders, defendersColumn);
                AddPlayersToColumn(midfields, midfieldColumn);
                AddPlayersToColumn(forwards, forwardColumn);
            }
            else if (team == "away")
            {
                awayGoalieColumn.Children.Add(goalie);
                AddPlayersToColumn(defenders, awayDefendersColumn);
                AddPlayersToColumn(midfields, awayMidfieldColumn);
                AddPlayersToColumn(forwards, awayForwardColumn);
            }
        }

        private void AddPlayersToColumn(List<Player> players, StackPanel column)
        {
            ColumnDefinition defendersColumn = new ColumnDefinition();
            foreach (Player player in players)
            {
                PlayerUC playerUC = new PlayerUC(images);
                playerUC.LoadData(player);
                playerUC.MouseDoubleClick += player_MouseDoubleClick;
                column.Children.Add(playerUC);
            }
        }

        private void player_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerUC playerUC = sender as PlayerUC;
            PlayerDetails playerDetails = new PlayerDetails(images);

            playerDetails.LoadData(playerUC.GetData(), match);
            playerDetails.ShowDialog();
        }

        private void LoadGoals(Team homeTeam, Team awayTeam)
        {
            lblResult.Content = $"{homeTeam.Goals} : {awayTeam.Goals}";
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MyMessage myMessage = new MyMessage("Are you shure you want to edit settings?");
            myMessage.ShowDialog();
            if (myMessage.Save)
            {
                editing = true;
                settingsDefault.Show();
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!editing)
            {
                MyMessage myMessage = new MyMessage("Save settings?");
                myMessage.ShowDialog();
                if (myMessage.Save)
                {
                    settings.Save(settings);
                }
                settingsDefault.Close();
            }
        }
    }
}
