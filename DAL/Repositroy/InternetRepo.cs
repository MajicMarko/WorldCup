using DAL.Interface;
using DAL.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositroy
{
    public class InternetRepo : IRepo
    {
        public string REPRESENTATION;
        public string URL;

        private Task<RestResponse<T>> GetData<T>(string source)
        {
            RestClient restClient = new RestClient("https://worldcup-vua.nullbit.hr/men/teams/results");
            return restClient.ExecuteAsync<T>(new RestRequest());
        }

        private T Desserialize<T>(RestResponse<T> restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse.Content);
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
            URL = $"https://worldcup-vua.nullbit.hr/{REPRESENTATION}/matches/country?fifa_code=" + fifaCode;
            IList<Match> matches = new List<Match>();
            IList<Player> players = new List<Player>();
            IList<TeamStatistics> teams = new List<TeamStatistics>();
            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(URL);
            matches = (IList<Match>)Desserialize<IList<Match>>(restResponse);
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
            URL = $"https://worldcup-vua.nullbit.hr/{REPRESENTATION}/teams/results";
            IList<Team> teams = new List<Team>();
            RestResponse<IList<Team>> restResponse = await GetData<IList<Team>>(URL);
            teams = (IList<Team>)Desserialize<IList<Team>>(restResponse);
            return teams;
        }

        public async Task<Team> LoadTeam(string fifaCode)
        {
            URL = $"https://worldcup-vua.nullbit.hr/{REPRESENTATION}/teams/results";
            Team team = new Team();
            IList<Team> teams = new List<Team>();
            RestResponse<IList<Team>> restResponse = await GetData<IList<Team>>(URL);
            teams = (IList<Team>)Desserialize<IList<Team>>(restResponse);
            team = teams.FirstOrDefault(t => t.FifaCode == fifaCode);
            return team;
        }

        public async Task<IList<Match>> LoadTeamRankings(string fifaCode)
        {
            URL = $"https://worldcup-vua.nullbit.hr/{REPRESENTATION}/matches/country?fifa_code=" + fifaCode;
            IList<Match> matches = new List<Match>();
            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(URL);
            matches = (IList<Match>)Desserialize<IList<Match>>(restResponse);
            return matches;
        }

        public async Task<IList<Match>> LoadMatches()
        {
            URL = $"https://worldcup-vua.nullbit.hr/{REPRESENTATION}/teams/results";
            IList<Match> matches = new List<Match>();
            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(URL);
            matches = (IList<Match>)Desserialize<IList<Match>>(restResponse);
            return matches;
        }

        public async Task<IList<Player>> LoadPlayerRankings(string fifaCode)
        {
            URL = $"https://worldcup-vua.nullbit.hr/{REPRESENTATION}/matches/country?fifa_code=" + fifaCode;
            IList<Match> matches = new List<Match>();
            IList<Player> players = new List<Player>();
            IList<TeamStatistics> teams = new List<TeamStatistics>();
            IList<TeamEvent> happenings = new List<TeamEvent>();
            RestResponse<IList<Match>> restResponse = await GetData<IList<Match>>(URL);
            matches = (IList<Match>)Desserialize<IList<Match>>(restResponse);


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
                    if (players.FirstOrDefault(e => e.Name == player.Name) == null)
                    {
                        player.Apearences = 1;
                        players.Add(player);
                    }
                    else
                    {
                        players.FirstOrDefault(p => p.Name == player.Name).Apearences++;
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

            foreach (TeamEvent happening in happenings)
            {
                switch (happening.TypeOfEvent)
                {
                    case TeamEvent.TypeOfEventE.Goal:
                        players.FirstOrDefault(p => happening.Player == p.Name).Scored++;
                        break;
                    case TeamEvent.TypeOfEventE.GoalPenalty:
                        players.FirstOrDefault(p => happening.Player == p.Name).Scored++;
                        break;
                    case TeamEvent.TypeOfEventE.YellowCard:
                        players.FirstOrDefault(p => happening.Player == p.Name).YellowCards++;
                        break;
                    case TeamEvent.TypeOfEventE.YellowCardSecond:
                        players.FirstOrDefault(p => happening.Player == p.Name).YellowCards++;
                        break;
                    case TeamEvent.TypeOfEventE.SubstitutionIn:
                        players.FirstOrDefault(p => happening.Player == p.Name).Apearences++;
                        break;
                }
            }

            return players;
        }
    }
}
