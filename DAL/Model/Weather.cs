using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace DAL.Model
{
    public class Weather
    {
        public enum DescriptionE
        {
            [EnumMember(Value = "Clear Night")]
            ClearNight,
            Cloudy,
            [EnumMember(Value = "Partly Cloudy")]
            PartlyCloudy,
            [EnumMember(Value = "Partly Cloudy Night")]
            PartlyCloudyNight,
            [EnumMember(Value = "Cloudy Night")]
            CloudyNight,
            Sunny
        };


        [JsonProperty("humidity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? WindSpeed { get; set; }

        [JsonProperty("description")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DescriptionE Description { get; set; }
    }
}
