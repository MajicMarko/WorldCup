using Newtonsoft.Json;
using System.Collections.Generic;

namespace DAL.Model
{
    public class Group
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("letter")]
        public string Letter { get; set; }

        [JsonProperty("ordered_teams")]
        public List<Team> OrderedTeams { get; set; }
    }
}
