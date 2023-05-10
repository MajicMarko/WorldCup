using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo
    {
        void Settings(Settings settings);
        Task<IList<Team>> LoadTeams(Settings settings);
        Task<IList<Match>> LoadMatches();
        Task<IList<Player>> LoadPlayers(string fifaCode);
        Task<IList<Match>> LoadTeamRankings(string fifaCode);
        Task<IList<Player>> LoadPlayerRankings(string fifaCode);
        Task<Team> LoadTeam(string fifaCode);
    }
}
