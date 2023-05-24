using DAL.Interface;
using DAL.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositroy
{
    public class InternetRepo : IRepo
    {
        public string REPRESENTATION;
        public string URL;

        private async Task<RestResponse<T>> GetData<T>(string source)
        {
            RestClient restClient = new RestClient("https://worldcup-vua.nullbit.hr/men/teams/results");
            RestRequest restRequest = new RestRequest();

            return await restClient.ExecuteAsync<T>(restRequest);
        }

        private T Deserialize<T>(RestResponse<T> restResponse)
        {
            string jsonContent = restResponse.Content;

            try
            {
                T deserializedObject = JsonConvert.DeserializeObject<T>(jsonContent);
                return deserializedObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return default; // Return default value for type T (e.g., null for reference types)
            }
        }




        public void Settings(Settings settings)
        {
            if (settings.Championship == Model.Settings.ChampionshipE.Women)
            {
                REPRESENTATION = settings.Female;
            }
            if (settings.Championship == Model.Settings.ChampionshipE.Men)
            {
                REPRESENTATION = settings.Male;
            }
        }

        public async Task<IList<Player>> LoadPlayers(string fifaCode)
        {
            URL = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=" + fifaCode;
            IList<Match> matches = new List<Match>();
            IList<Player> players = new List<Player>();
            IList<TeamStatistics> teams = new List<TeamStatistics>();
            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(URL);
            matches = Deserialize<IList<Match>>(restResponse);
            foreach (Match match in matches)
            {
                if (match.HomeTeam.Code == fifaCode)
                {
                    teams.Add(match.HomeTeamStatistics);
                }
                if (match.AwayTeam.Code == fifaCode)
                {
                    teams.Add(match.AwayTeamStatistics);
                }
            }
            foreach (TeamStatistics team in teams)
            {
                foreach (Player player in team.StartingEleven)
                {
                    if (players.FirstOrDefault(e => e.Name == player.Name) == null)
                    {
                        players.Add(player);
                    }
                }
                foreach (Player player in team.Substitutes)
                {
                    if (players.FirstOrDefault(e => e.Name == player.Name) == null)
                    {
                        players.Add(player);
                    }
                }
            }
            return players;
        }


        public async Task<IList<Team>> LoadTeams(Settings settings)
        {
            string url = "https://worldcup-vua.nullbit.hr/men/teams/results";
            IList<Team> teams = new List<Team>();
            RestResponse<IList<Team>> restResponse = await GetData<IList<Team>>(url);
            teams = Deserialize<IList<Team>>(restResponse);
            return teams;
        }


        public async Task<Team> LoadTeam(string fifaCode)
        {
            string url = "https://worldcup-vua.nullbit.hr/men/teams/results";
            Team team = null;
            IList<Team> teams = new List<Team>();
            RestResponse<IList<Team>> restResponse = await GetData<IList<Team>>(url);
            teams = Deserialize<IList<Team>>(restResponse);
            team = teams.FirstOrDefault(t => t.FifaCode == fifaCode);
            return team;
        }


        public async Task<IList<Match>> LoadTeamRankings(string fifaCode)
        {
            string url = $"https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code={fifaCode}";
            IList<Match> matches = new List<Match>();
            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(url);
            matches = Deserialize<IList<Match>>(restResponse);
            return matches;
        }


        public async Task<IList<Match>> LoadMatches()
        {
            string url = "https://worldcup-vua.nullbit.hr/men/teams/results";
            IList<Match> matches = new List<Match>();
            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(url);
            matches = Deserialize<IList<Match>>(restResponse);
            return matches;
        }


        public async Task<IList<Player>> LoadPlayerRankings(string fifaCode)
        {
            string url = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=" + fifaCode;
            IList<Match> matches = new List<Match>();
            IList<Player> players = new List<Player>();
            IList<TeamStatistics> teams = new List<TeamStatistics>();
            IList<TeamEvent> happenings = new List<TeamEvent>();

            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(url);
            matches = Deserialize<IList<Match>>(restResponse);

            foreach (Match match in matches)
            {
                if (match.HomeTeam.Code == fifaCode)
                {
                    foreach (TeamEvent teamEvent in match.HomeTeamEvents)
                    {
                        happenings.Add(teamEvent);
                    }
                    teams.Add(match.HomeTeamStatistics);
                }
                if (match.AwayTeam.Code == fifaCode)
                {
                    foreach (TeamEvent teamEvent in match.AwayTeamEvents)
                    {
                        happenings.Add(teamEvent);
                    }
                    teams.Add(match.AwayTeamStatistics);
                }
            }

            foreach (TeamStatistics team in teams)
            {
                foreach (Player player in team.StartingEleven)
                {
                    Player existingPlayer = players.FirstOrDefault(p => p.Name == player.Name);
                    if (existingPlayer == null)
                    {
                        player.Apearences = 1;
                        players.Add(player);
                    }
                    else
                    {
                        existingPlayer.Apearences++;
                    }
                }
                foreach (Player player in team.Substitutes)
                {
                    if (players.FirstOrDefault(p => p.Name == player.Name) == null)
                    {
                        players.Add(player);
                    }
                }
            }

            foreach (TeamEvent happening in happenings)
            {
                Player player = players.FirstOrDefault(p => p.Name == happening.Player);
                if (player != null)
                {
                    switch (happening.TypeOfEvent)
                    {
                        case TeamEvent.TypeOfEventE.Goal:
                        case TeamEvent.TypeOfEventE.GoalPenalty:
                            player.Scored++;
                            break;
                        case TeamEvent.TypeOfEventE.YellowCard:
                        case TeamEvent.TypeOfEventE.YellowCardSecond:
                            player.YellowCards++;
                            break;
                        case TeamEvent.TypeOfEventE.SubstitutionIn:
                            player.Apearences++;
                            break;
                    }
                }
            }

            return players;
        }

    }
}
