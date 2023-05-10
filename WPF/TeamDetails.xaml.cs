using DAL.Interface;
using DAL.Model;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        private static IRepo repo;
        private Team team;
        public TeamDetails(IRepo repository)
        {
            repo = repository;
            InitializeComponent();
        }

        internal async Task LoadData(Team selectedTeam)
        {
            try
            {
                team = await repo.LoadTeam(selectedTeam.FifaCode);
                lblTeamName.Content = team.Country;
                lblFifaCode.Content = $"({team.FifaCode})";
                lblGamesPlayed.Content = team.GamesPlayed;
                lblGameWins.Content = team.Wins;
                lblGameLosses.Content = team.Losses;
                lblGameDraws.Content = team.Draws;
                lblGoalsDifferential.Content = team.GoalDifferential;
                lblGoalsFor.Content = team.GoalsFor;
                lblGoalsAgainst.Content = team.GoalsAgainst;
            }
            catch (Exception)
            {
                lblTeamName.Content = "Error";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

