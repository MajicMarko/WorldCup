using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace DAL.Model
{
    public class TeamEvent
    {
        public enum TypeOfEventE
        {
            Goal,
            [EnumMember(Value = "Goal-Own")]
            GoalOwn,
            [EnumMember(Value = "Goal-Penalty")]
            GoalPenalty,
            [EnumMember(Value = "Red-Card")]
            RedCard,
            [EnumMember(Value = "substitution-in")]
            SubstitutionIn,
            [EnumMember(Value = "substitution-out")]
            SubstitutionOut,
            [EnumMember(Value = "Yellow-Card")]
            YellowCard,
            [EnumMember(Value = "Yellow-Card-Second")]
            YellowCardSecond
        };

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public TypeOfEventE TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
        //public int Id { get; set; }
        //public string TypeOfEvent { get; set; }
        //public Player Player { get; set; }
        //public string Time { get; set; }
    }
}
