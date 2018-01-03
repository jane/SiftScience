using Newtonsoft.Json;

namespace SiftScience.Scores
{
    public class HistoryItem
    {
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("config")]
        public AppConfig Config { get; set; }
    }
}
