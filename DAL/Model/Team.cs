using Newtonsoft.Json;
using System;
using System.Linq;

namespace DAL.Model
{
    public class Team : IComparable<Team>
    {
        private static readonly char DEL = '|';

        public int CompareTo(Team other)
        {
            return Country.CompareTo(other.Country);
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

        internal string ParseForFileLine() => $"{Country}{DEL}{FifaCode}";
        internal static Team ParseFromFile(string line)
        {
            Team team = new Team
            {
                Country = line.Split(DEL).First(),
                FifaCode = line.Split(DEL).Last()
            };

            return team;
        }

        public override string ToString() => $"{Country} ({FifaCode})";

        public override bool Equals(object obj)
        {
            Team other = obj as Team;
            if (FifaCode == null)
            {
                FifaCode = Code;
            }

            return FifaCode.Equals(other.FifaCode != null ? other.FifaCode : other.Code);
        }
    }
}
